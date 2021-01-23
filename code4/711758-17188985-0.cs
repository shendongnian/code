		public async void DoMyCommand()
		{
			IsBusy = true;
			try{
				await Task.Factory.StartNew(() =>
				                            {
					_myService.LongRunningProcess();
				});
			}catch{
				//Log Exception
			}finally{
				IsBusy = false;
			}
		}
