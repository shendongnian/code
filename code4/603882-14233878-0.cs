    MyTabB_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
         TabControl tc= ((TabControl)sender;
         if(tc.SelectedIndex == tc.Items.IndexOf(A/*Login tab*/))
          {
             MessageBox.Show("Login")
             tc.SelectedIndex = tc.Items.IndexOf(B);
          }
    }
