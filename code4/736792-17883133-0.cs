    private void search(object sender, RoutedEventArgs e)
    {
        int n;
        if(int.TryParse(number.Text, out n))
        {
           if (n < 455)
           {
               var rs = Application.GetResourceStream(new Uri("def/f" + number.Text + ".html", UriKind.Relative));
               StreamReader sr = new StreamReader(rs.Stream);
               browser.NavigateToString(sr.ReadToEnd());
           }
           else
           {
               MessageBox.Show("Enter Value between 1 to 454");
           }
        }
    } 
