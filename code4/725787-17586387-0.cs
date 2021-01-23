    Button btn1 = new Button();
    btn1.Content = "content";
    btn1.Click+=btn1_Click;
    sp1.Children.Add(btn1);
<!== ==>
    private void btn1_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("You clicked it");
    }
