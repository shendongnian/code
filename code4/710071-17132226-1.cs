    test = new Ellipse();
    test.MouseDown += new MouseButtonEventHandler(test_MouseDown);
.
    void test_MouseDown(object sender, MouseButtonEventArgs e)
    {
        (sender as Ellipse).Fill = Brushes.Red;
    }
