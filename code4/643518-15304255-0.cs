    private void wbGoogle_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        var vm = (TypeOfMyViewModel) this.DataContext;
        //... read your HTML, get URL etc ...
        vm.WebBrowserNavigatedTo(url, html, loadTime);
    }
