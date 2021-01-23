		    var mdiChild = new MdiChild
		                       {
		                           Title = "Window Using Code",
		                           Content = new ExampleControl(),
		                           Width = 714,
		                           Height = 734,
		                           Position = new Point(200, 30)
		                       };
        mdiChild.Loaded += new RoutedEventHandler(mdiChild_Loaded);
			Container.Children.Add(mdiChild);
-----
        void mdiChild_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is MdiChild)
            {
                var width = (sender as MdiChild).Width;
                Debug.WriteLine("Width: {0}", width);
            }
        }
