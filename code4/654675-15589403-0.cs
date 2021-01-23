        if (ISFirstRender)
        {
            TabItem tabitem = new TabItem();
            tabitem.Header = "Tab 3";
            Frame tabFrame = new Frame();
            Page1 page1 = new Page1();
            tabFrame.Content = page1;
            tabitem.Content = tabFrame;
            pan1.Items.Add(tabitem);
            ISFirstRender = false;
        }
