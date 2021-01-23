    foreach (var menu in menuBuilder)
    {
        if (menu.Visible)
        {
            Button result =  menuButtons.Find(delegate(Button btn){ return (int)btn.Tag == (int)menu.Tag;});
            if(result != null){result.Visibility=Visibility.Visible;}
        }
    }
