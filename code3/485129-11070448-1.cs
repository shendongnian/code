    static void proxy_FindEmployeeCompleted(object sender, FindEmployeeCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
        }
        else if (e.Result != null)
        {
            // you can check results here. 
            if (e.Result.Any())
            {
                listBox1.ItemsSource = e.Result;
            }else
            {
                // empty result, show message or whatever 
            }
        }
        else
        {
            MessageBox.Show("Invalid username or password.");
        }
    }
