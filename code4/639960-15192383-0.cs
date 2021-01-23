    win2 v2 = null;
    private void button1_Click(object sender, RoutedEventArgs e)
    {
       
       if (v2 == null)
        {
           v2 = new win2();
           v2.Show();
        }
        else
           v2.Activate();
    }
