    Button btn1 = new Button();
    btn1.Content = qhm.Option1;
    btn1.Click += btn_Click;
    sp1.Children.Add(btn1);
    
    
    //separate method
    private void btn_Click(object sender, RoutedEventArgs e)
    {
        tbox.Text = qhm.Option1;
    }
