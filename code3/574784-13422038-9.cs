    [TestMethod]
		public void TestMethod3()
		{
			// Creates the viewmodel with the necessary infomation wherever 
                        // you need to.
			MyViewModel viewModel = new MyViewModel(string infoFromOffice);
			// The dispatcher thread
			var t = new Thread(() =>
			{
				var app = new App();
				// Corrects the error "System.IO.IOException: Assembly.GetEntryAssembly() returns null..."
				App.ResourceAssembly = app.GetType().Assembly;
				app.InitializeComponent();
				// Creates the Window in the App's Thread and pass the information to it
				MyWindow view = new MyWindow();
				view.DataContext = viewModel;
				app.Run(view);
			});
			// Configure the thread
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
			t.Join();
		}
