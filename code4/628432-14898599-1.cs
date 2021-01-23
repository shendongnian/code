    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Threading;
    using HQ.Util.General.Threading;
    using HQ.Util.Unmanaged;
    
    namespace HQ.Wpf.Util.Dialog
    {
    	/// <summary>
    	/// Interaction logic for DlgProgressWithProgressStatus.xaml
    	/// </summary>
    	public partial class DlgProgress : Window
    	{
    		// ******************************************************************
    		private readonly DlgProgressModel _dlgProgressModel;
    
    		// ******************************************************************
    		public static DlgProgress CreateProgressBar(Window owner, DlgProgressModel dlgProgressModel)
    		{
    			DlgProgress dlgProgressWithProgressStatus = null;
    			var listDlgProgressWithProgressStatus = new List<DlgProgress>();
    			var resetEvent = new AutoResetEvent(false);
    
    			IntPtr windowHandleOwner = new WindowInteropHelper(owner).Handle;
    			dlgProgressModel.Owner = owner;
    			dlgProgressModel.IntPtrOwner = windowHandleOwner;
    			
    			var workerThread = new ThreadEx(() => StartDlgProgress(dlgProgressModel, resetEvent, listDlgProgressWithProgressStatus));
    			workerThread.Thread.SetApartmentState(ApartmentState.STA);
    			workerThread.Start();
    			resetEvent.WaitOne(10000);
    			if (listDlgProgressWithProgressStatus.Count > 0)
    			{
    				dlgProgressWithProgressStatus = listDlgProgressWithProgressStatus[0];
    			}
    
    			return dlgProgressWithProgressStatus;
    		}
    
    		// ******************************************************************
    		private static void StartDlgProgress(DlgProgressModel progressModel, AutoResetEvent resetEvent, List<DlgProgress> listDlgProgressWithProgressStatus)
    		{
    			DlgProgress dlgProgress = new DlgProgress(progressModel);
    			listDlgProgressWithProgressStatus.Add(dlgProgress);
    			dlgProgress.ShowDialog();
    			resetEvent.Set();
    		}
    
    		// ******************************************************************
    		private DlgProgress(DlgProgressModel dlgProgressModel)
    		{
    			if (dlgProgressModel.Owner == null)
    			{
    				throw new ArgumentNullException("Owner cannot be null");
    			}
    
    			InitializeComponent();
    			// this.Owner = owner; // Can't another threads owns it exception
    
    			if (dlgProgressModel == null)
    			{
    				throw new ArgumentNullException("dlgProgressModel");
    			}
    
    			_dlgProgressModel = dlgProgressModel;
    			_dlgProgressModel.Dispatcher = this.Dispatcher;
    			_dlgProgressModel.PropertyChanged += _dlgProgressModel_PropertyChanged;
    			DataContext = _dlgProgressModel;
    		}
    
    		// ******************************************************************
    		// Should be call as a modal dialog
    		private new void Show()
    		{
    			throw new Exception("Should only be used as modal dialog");
    		}
    
    		// ******************************************************************
    		void _dlgProgressModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    		{
    			if (e.PropertyName == "IsConditionToCloseMet")
    			{
    				if (_dlgProgressModel.IsActionCanceled == true)
    				{
    					this.DialogResult = true;
    				}
    			}
    		}
    
    		private bool _isFirstTimeLoaded = true;
    		// ******************************************************************
    		private void WindowLoaded(object sender, RoutedEventArgs e)
    		{
    			if (_isFirstTimeLoaded)
    			{
    				WindowHelper.SetOwnerWindow(this, _dlgProgressModel.IntPtrOwner);
    				Dispatcher.BeginInvoke(new Action(ExecuteDelayedAfterWindowDisplayed), DispatcherPriority.Background);
    				_isFirstTimeLoaded = false;
    			}
    		}
    
    		// ******************************************************************
    		private void ExecuteDelayedAfterWindowDisplayed()
    		{
    			if (_dlgProgressModel._actionStarted == false)
    			{
    				// ExecuteAction();
    				_dlgProgressModel._actionStarted = true;
    				Task.Factory.StartNew(ExecuteAction);
    			}
    		}
    
    		// ******************************************************************
    		private void ExecuteAction()
    		{
    			_dlgProgressModel.ExecuteAction();
    			_dlgProgressModel._actionTerminated = true;
    			_dlgProgressModel.VerifyIfCloseWindowConditionIsMet();
    		}
    
    		// ******************************************************************
    		private void CmdCancel_Click(object sender, RoutedEventArgs e)
    		{
    			this._dlgProgressModel.IsActionCanceled = true;
    			this.DialogResult = false;
    		}
    
    		//// ******************************************************************
    		//private void Test_Click(object sender, RoutedEventArgs e)
    		//{
    		//	Debug.Print(this.ProgressBar.Minimum.ToString() + ", " + this.ProgressBar.Maximum.ToString());
    		//	Debug.Print(this.ProgressBar.Value.ToString());
    		//	Debug.Print(this._dlgProgressModel.ValueCurrent.ToString());
    		//}
    
    		// ******************************************************************
    		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    		{
    			if (! _dlgProgressModel.IsConditionToCloseMet)
    			{
    				e.Cancel = true;
    				return;
    			}
    
    			this.CmdCancel.IsEnabled = false;
    			this.CmdCancel.Content = "Canceling...";
    			this._dlgProgressModel.Dispose();
    		}
    
    		// ******************************************************************
    	}
    }
