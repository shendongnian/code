employeeTabList.SelectedSourceChanged += employeeTabList_SelectedSourceChanged;
    void employeeTabList_SelectedSourceChanged(object sender, SourceEventArgs e)
    {
        if (e.Source.OriginalString.EndsWith("EditEmployeeDetail.xaml"))
        {
            var url = "/Pages/EditEmployeeDetail.xaml";
            var bb = new BBCodeBlock();
            bb.LinkNavigator.Navigate(new Uri(url, UriKind.Relative), this, NavigationHelper.FrameTop);
            // You may want to set some property in that page's ViewModel, for example, indicating the selected User ID.
        }
    }
