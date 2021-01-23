        var products = new TreeViewItem {Header = "Products"};
        var mediaPlayers = new TreeViewItem() {Header = "Media Players"};
        var charts = new TreeViewItem() { Header = "Charts" };
        var games = new TreeViewItem() { Header = "Games" };
                   
        products.Items.Add(mediaPlayers);
        mediaPlayers.Items.Add(games);
        games.Items.Add(charts);
    
    MyTreeView1.Items.Add(products);
