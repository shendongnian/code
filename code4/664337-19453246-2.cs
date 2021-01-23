        private MyDataContext GetMyDataContext()
        {
            var candidate = FindResource("myDataContext") as MyDataContext;
            if (candidate == null) throw new ApplicationException("Could not locate the myDataContext object");
            return candidate;
        }
        private void OnButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GetMyDataContext().SetOption("On");            
        }
        private void OffButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GetMyDataContext().SetOption("Off");
        }
