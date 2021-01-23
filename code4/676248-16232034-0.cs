            private void functionToHandleTap(string i)
        {
            string naviString = string.Empty;
            if (i == "something")
            {
                naviString = "some xaml here";
            }
            else
            {
                naviString = "another xaml here";
            }
            _rootFrame.Navigate(new Uri(naviString, UriKind.Relative));
        }
