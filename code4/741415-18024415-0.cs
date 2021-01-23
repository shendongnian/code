    public MainPage()
    {
        this.InitializeComponent();
        Loaded += MainPage_Loaded;
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var textBox in AllTextBoxes(this))
        {
            textBox.Text = "Hello world";
        }
    }
    List<TextBox> AllTextBoxes(DependencyObject parent)
    {
        var list = new List<TextBox>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is TextBox)
                list.Add(child as TextBox);
            list.AddRange(AllTextBoxes(child));
        }
        return list;
    }
