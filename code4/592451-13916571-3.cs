    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (NavigationContext.QueryString.ContainsKey("action"))
        {
            if (NavigationContext.QueryString["action"]=="load")
            {
                PageTitle.Text = "edit gift";
                giftVm.Gift = App._context.Gifts.Single(g => g.Id == Int32.Parse(NavigationContext.QueryString["id"]));                    
            }
            else if (NavigationContext.QueryString["action"] == "new")
            {
                PageTitle.Text = "new gift";
            }
            else if (NavigationContext.QueryString["action"] == "newWishList")
            {
                App.vm = ((MainViewModel)App.vm).Me;
            }
        }
        else
        {
            MessageBox.Show("NavigationContext.QueryString.ContainsKey('action') is false");
        }
    }
