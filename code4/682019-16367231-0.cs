    public StartPage()
    {
        InitializeComponent();
        cityPicker.ItemsSource = new[] { "city1", "city2" };
        cityPicker.SelectionChanged += CityPickerSelectionChanged;
    }
    
    void CityPickerSelectionChanged(object sender, SelectioChangedEventArgs e)
    {
        // get your roaming settings
        var selectedItem = cityPicker.SelectedItem;
        roamingSettings.Values["SelectedCity"] = (string) selectedItem;
    }
    protected override void LoadState(...)
    {
        // get roaming settings, perform key check
        cityPicker.SelectedValue = (string) (roamingSettings.Values["SelectedCity"]);
    }
