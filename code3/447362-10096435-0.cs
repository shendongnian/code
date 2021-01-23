    public class MyViewModel
	{
		public RelayCommand SaveAsClickCmd
		{
			get {
				return _saveAsClickCmd ?? (_saveAsClickCmd = new RelayCommand(() => {
					var dialog = new Microsoft.Win32.SaveFileDialog();
					if (dialog.ShowDialog() != true)
						return;
					using (var stream = dialog.OpenFile()) {
						//write out file to disk
					}
				}));
			}
		}
		private RelayCommand _saveAsClickCmd;
	}
