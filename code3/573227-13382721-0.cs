    [TestMethod]
		public void TestMethod1()
		{
			MainWindow window = null;
			// The dispatcher thread
			var t = new Thread(() =>
			{
				window = new MainWindow();
				// Initiates the dispatcher thread shutdown when the window closes
				window.Closed += (s, e) => window.Dispatcher.InvokeShutdown();
				window.Show();
				// Makes the thread support message pumping
				System.Windows.Threading.Dispatcher.Run();
			});
			// Configure the thread
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
			t.Join();
		}
