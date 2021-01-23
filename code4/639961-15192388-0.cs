     private void button1_Click(object sender, RoutedEventArgs e)
        {
    		if(!Application.Current.Windows.OfType<win2>().Any())
    		{
    			win2 v2 = new win2();
    			v2.Show();
    		}	
        }
