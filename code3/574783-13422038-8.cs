    [TestMethod]
		public void TestMethod()
		{
			// The dispatcher thread
			var t = new Thread(() =>
			{
				var app = new App();
				// Corrects the error "System.IO.IOException: Assembly.GetEntryAssembly() returns null..."
				App.ResourceAssembly = app.GetType().Assembly;
				app.InitializeComponent();
				app.Run();
			});
			// Configure the thread
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
			t.Join();
		}
