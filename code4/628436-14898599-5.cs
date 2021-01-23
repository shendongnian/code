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
    			var resetEvent = new ManualResetEvent(false);
    
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
    		private static void StartDlgProgress(DlgProgressModel progressModel, ManualResetEvent resetEvent, List<DlgProgress> listDlgProgressWithProgressStatus)
    		{
    			DlgProgress dlgProgress = new DlgProgress(progressModel);
    			listDlgProgressWithProgressStatus.Add(dlgProgress);
    			resetEvent.Set();
    			dlgProgress.ShowDialog();
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
    
    			//			if (e.PropertyName == "IsJobCanceled" || e.PropertyName == "IsJobCompleted" || e.PropertyName == "IsProgressCompleted")
    			// Faster if we don't check strings and check condition directly 
    			{
    				if (_dlgProgressModel.HaveConditionToClose())
    				{
    					if (_dlgProgressModel.IsJobCanceled == true)
    					{
    						SetDialogResult(false);
    					}
    					else
    					{
    						SetDialogResult(true);
    					}
    				}
    			}
    		}
    
    		// ******************************************************************
    		private void SetDialogResult(bool result)
    		{
    			this._dlgProgressModel.Dispatcher.BeginInvoke(new Action(() =>
    				{
    					this.DialogResult = result;
    				}), DispatcherPriority.Background);
    		}
    
    		// ******************************************************************
    		private bool _isFirstTimeLoaded = true;
    
    		private Timer _timer = null;
    		// ******************************************************************
    		private void WindowLoaded(object sender, RoutedEventArgs e)
    		{
    			if (_isFirstTimeLoaded)
    			{
    				WindowHelper.SetOwnerWindow(this, _dlgProgressModel.IntPtrOwner);
    				Dispatcher.BeginInvoke(new Action(ExecuteDelayedAfterWindowDisplayed), DispatcherPriority.Background);
    				_isFirstTimeLoaded = false;
    
    				if (_dlgProgressModel.FuncGetProgressPercentageValue != null)
    				{
    					TimerCallback(null);
    					_timer = new Timer(TimerCallback, null, _dlgProgressModel.MilliSecDelayBetweenCall, _dlgProgressModel.MilliSecDelayBetweenCall);
    				}
    			}
    		}
    
    		// ******************************************************************
    		private void TimerCallback(Object state)
    		{
    			Dispatcher.BeginInvoke(new Action(() =>
    				{
    					_dlgProgressModel.ValueCurrent = _dlgProgressModel.FuncGetProgressPercentageValue();
    				}));
    		}
    		
    		// ******************************************************************
    		private void ExecuteDelayedAfterWindowDisplayed()
    		{
    			if (_dlgProgressModel._actionStarted == false)
    			{
    				_dlgProgressModel._actionStarted = true;
    				Task.Factory.StartNew(ExecuteAction);
    			}
    		}
    
    		// ******************************************************************
    		private void ExecuteAction()
    		{
    			_dlgProgressModel.ExecuteAction();
    			_dlgProgressModel._actionTerminated = true;
    			_dlgProgressModel.IsJobCompleted = true;
    		}
    
    		// ******************************************************************
    		private void CmdCancel_Click(object sender, RoutedEventArgs e)
    		{
    			this._dlgProgressModel.IsJobCanceled = true;
    		}
    
    		// ******************************************************************
    		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    		{
    			if (! _dlgProgressModel.HaveConditionToClose())
    			{
    				e.Cancel = true;
    				return;
    			}
    
    			WindowHelper.SetOwnerWindow(this, 0);
    
    			this.CmdCancel.IsEnabled = false;
    			this.CmdCancel.Content = "Canceling...";
    			this._dlgProgressModel.Dispose();
    		}
    
    		// ******************************************************************
    	}
    }
