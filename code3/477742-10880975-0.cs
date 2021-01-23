    public partial class ComboBox : Window
    {
      int intex_count;
      List<object> items;
      public ComboBox()
      {
        this.InitializeComponent();         
        add_items();
        //key_value();
        TextBox tb = new TextBox();
        tb.Height = 50;
        tb.Width = 100;
        tb.TextAlignment = TextAlignment.Center;
        LayoutRoot.Children.Add(tb);
        tb.Text = "Dynamic TextBox";
        tb.Margin = new Thickness(0, 145, 87, 0);
        tb.VerticalAlignment = VerticalAlignment.Top;
        tb.HorizontalAlignment = HorizontalAlignment.Right;
        tb.Padding = new Thickness(15, 15, 15, 15); //to center the textbox's text  
        
        items = new List<object>();
        com_add_remove.ItemsSource = items;
        com_add_remove.SelectedIndex = 0;
    }
    public List<object> add_items()
    {
        //List<object> items = new List<object>();
        items.Add("chandru");
        items.Add(83);        
        return items;
    }
    
    private void btn_add_Click(object sender, RoutedEventArgs e)
    {
         items.Remove(txt_item.Text);
         intex_count = items.Count;
    }
