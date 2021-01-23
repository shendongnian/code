    List<SolidColorBrush> colors;
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        colors = new List<SolidColorBrush> 
        {
            new SolidColorBrush(Windows.UI.Colors.Red),
            new SolidColorBrush(Windows.UI.Colors.Gainsboro),
            new SolidColorBrush(Windows.UI.Colors.BlanchedAlmond),
            new SolidColorBrush(Windows.UI.Colors.Turquoise),
            new SolidColorBrush(Windows.UI.Colors.Azure),
            new SolidColorBrush(Windows.UI.Colors.Teal),
            new SolidColorBrush(Windows.UI.Colors.Tan),
            new SolidColorBrush(Windows.UI.Colors.PowderBlue),
            new SolidColorBrush(Windows.UI.Colors.WhiteSmoke),
            new SolidColorBrush(Windows.UI.Colors.SeaGreen)
        };
        for (int i = 0; i < 10; i++)
        {
            flipview.Items.Add(AddNewGridview(i));
        }
    }
    
    int i = 1, j = 0;
    GridView AddNewGridview(int k)
    {
        var gv = new GridView();
        gv.Background = colors[k];
        gv.ItemTemplate = this.Resources["MyTemplate"] as DataTemplate;
        List<int> IDs = new List<int>();
        while(i < 17 + j)
        {
            IDs.Add(i);
            i++;
        }
        j = i - 1;
        gv.ItemsSource = IDs;
        return gv;
    }
