        ..Code snippet.............
        public DotNotLiveJustForEvent()
        {
            ClickedHandler = new RoutedEventHandler(Clicked);
        }
        //Add a member variable that references the Clicked method
        public RoutedEventHandler ClickedHandler = null;
        public void Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(DateTime.Now.ToShortDateString());
        }
        ...............
        ..Code snippet.............
            //The input parameter is changed to the variable
            btnTest.Click+= new WeakEventHandler(new DotNotLiveJustForEvent().ClickedHandler) {
                RemoveDelegateCode = eh =>
                {
                   // btnTest.Click -= eh;
                }
            };
       ...............
