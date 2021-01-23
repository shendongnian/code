		public static void InstallItemsInLayoutControl(LayoutControl layoutControl)
		{
			// FAKE TEST VERSION
			Button btn = new Button();
			btn.Name = "TESTBUTTON";
			btn.Content = "Test Me";
			btn.Height = 23;
			btn.Width = 100;
			btn.HorizontalAlignment = HorizontalAlignment.Left;
			btn.VerticalAlignment = VerticalAlignment.Top;
			btn.Width = 100;
			layoutControl.RegisterName(btn.Name, btn);  // THIS LINE WAS MISSING
			layoutControl.Children.Add(btn);
		}
