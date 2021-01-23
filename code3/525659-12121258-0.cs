    void loadItems(){
    //load
        var t = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
                t.Tick += delegate {
                  _ScrollViewer.UpdateLayout();
                  SomethingLoading = false;
                  listmy.ScrollIntoView(listmy.Items[listmy.Items.Count - 10]);
                };
                t.Start();
    }
