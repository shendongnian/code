        if (strAdmin == "False")
        {
            MenuItem mnuItem = Menu1.FindItem("Reports"); // Find particular item
            Menu1.Items.Remove(mnuItem);
            MenuItem mnuItem1 = Menu1.FindItem("Master"); // Find particular item
            Menu1.Items.Remove(mnuItem1);
            Menu1.Width = Unit.Percentage(30);
        }
    }
