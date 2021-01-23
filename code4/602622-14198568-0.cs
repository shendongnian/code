    public class DialogService : IDisposable
	{
		#region Member Variables
		private static volatile DialogService instance;
		private static object syncroot = new object();
		#endregion
		#region Ctr
		private DialogService()
		{
		}
		#endregion
		#region Public Methods
		public void ShowDialog(object _callerContentOne, object _callerContentTwo)
		{
			MyDialogViewModel viewmodel = new MyDialogViewModel(_callerContentOne, _callerContentTwo);
			MyDialogView view = new MyDialogView();
			view.DataContext = viewmodel;
			view.ShowDialog();
		}
		#endregion
		#region Private Methods
		#endregion
		#region Properties
		public DialogService Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncroot)
					{
						if (instance == null)
						{
							instance = new DialogService();
						}
					}
				}
				return instance;
			}
		}
		#endregion
	}
