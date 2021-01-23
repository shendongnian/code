        private void btn_Click(object sender, RoutedEventArgs e)
        {
             Button btn = sender as Buttonl;
             if(btn!=null)
             {
                 Point renderedLocation = btn.TranslatePoint(new Point(0, 0), this);
             }
             else
             {
                  //you may throw an exception if you want.
             }
        }
