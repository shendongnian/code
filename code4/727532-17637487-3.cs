    protected override void OnNavigatedTo(NavigationEventArgs e) {
        base.OnNavigatedTo(e);
        if (this.ListBox1.ItemsSource == null) {
            object list;
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("List", out list)) {
                this.ListBox1.ItemsSource = new List<string>((string[]) list);
            } else {
                this.ListBox1.ItemsSource = new List<string>();  
            }
        }
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e) {
        if (this.ListBox1.ItemsSource != null) {
            ApplicationData.Current.LocalSettings.Values["List"] = this.ListBox1.ItemsSource.ToArray();         
        }
        base.OnNavigatedFrom(e);
    }
