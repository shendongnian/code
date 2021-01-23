			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += (sender, args) =>
			             	{
								for (int i = 0; i < 10000; ++i)
								{
									DoSomeWorkInBackground();
									// Update the label in UI thread
									MyOtherFormInstance.Invoke((MethodInvoker)delegate()
									                                          	{
									                                          		MyOtherFormInstance.SetLabelText(i);
									                                          	});
									DoSomOtherWorkInBackground();
								}
			             	};
