    Window1 w1 = null;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(w1 == null)
        {
            w1 = new Window1();
            w1.MainWindow = this; //create this property - see below
            w1.Show();
        }
        else
            w1.Visible = true;
        this.Visible = false;
    }
