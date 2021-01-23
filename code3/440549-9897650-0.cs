    cM.Items.Clear();
    cM.Items.Add(new MenuItem() { Header = "Barclays PL" });
    cM.Items.Add(new MenuItem() { Header = "Championship" });
    cM.Items.Add(new MenuItem() { Header = "League 1" });
    cM.Items.Add(new MenuItem() { Header = "League 2" });
    cM.Items.Add(new MenuItem() { Header = "Conference" });
    
    foreach( var item in cM.Items ) {
      ((MenuItem)item).Tap += MenuItem_Tap1;
    }
