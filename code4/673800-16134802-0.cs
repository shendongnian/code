		private RelayCommand _DoLogFileWorkCommand;
		public RelayCommand DoLogFileWorkCommand {
			get {
				if (null == _DoLogFileWorkCommand) {
					_DoLogFileWorkCommand = new RelayCommand(
						(param) => true,
						(param) => { MessageBox.Show(param.ToString()); }
					);
				}
				return _DoLogFileWorkCommand;
			}
		}
