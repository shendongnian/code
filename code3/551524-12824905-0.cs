    private CancellationTokenSource _cancelAnalysisTask = new CancellationTokenSource();
		private Task _analysisTask;
		private void AnalysisClick(object sender, RoutedEventArgs e)
		{
			_analysisTask = Task.Factory.StartNew(() =>
				{
					if (_cancelAnalysisTask.IsCancellationRequested)
							return;
					model.RunAnalysis();
				});
		}
		private void CancelClick(object sender, RoutedEventArgs e)
		{
			if (_analysisTask != null)
			{
				_cancelAnalysisTask.Cancel();
				_analysisTask = null;
				MessageBox.Show("The Analysis was cancelled.", "Operation Cancelled", MessageBoxButton.OK);
			}
		}
