     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Button b = new Button();
            b.Content = "myitem";
            b.Click += new RoutedEventHandler(b_Click);
            listBox1.Items.Add(b);
        }
        void b_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Item CLicked");
        }
