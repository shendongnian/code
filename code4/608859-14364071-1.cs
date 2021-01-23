    private void button1_Click(object sender, RoutedEventArgs e)
    {
        TabItem item = null;
        Grid grid = null;
        TextBox textbox = null;
        try
        {
            // Creating the TextBox
            textbox = new TextBox();
            textbox.Width = 200;
            textbox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            textbox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            // Creating the Grid (create Canvas or StackPanel or other panel here)
            grid = new Grid();
            grid.Children.Add(textbox);     // Add more controls
            item = new TabItem();
            item.Header = "Hello, this is the new tab item!";
            item.Content = grid;            // OR : Add a UserControl containing all controls you like, OR use a ContentTemplate
            MyTabControl.Items.Add(item);
            MyTabControl.SelectedItem = item;   // Setting focus to the new TabItem
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error creating the TabItem content! " + ex.Message);
        }
        finally
        {
            textbox = null;
            grid = null;
            item = null;
        }
    }
