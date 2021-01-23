		public TaskGUIUpdater(Form1 form1, TaskDataGenerator taskDataGenerator)
		{
			Task.Factory.StartNew(() => {
				while (true)
				{
					form1.BeginInvoke(new Action(() => {
						form1.UpdateGUI(taskDataGenerator.Counter, taskDataGenerator.RandomData);
					}));
					Thread.Sleep(1000);
				}
			});
		}
