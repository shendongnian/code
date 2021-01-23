        var list = new List<ITemInListView>();
        var item1 = new ITemInListView()
        {
            message = "This is item1",
            level = Level.Warning
        };
        var item2 = new ITemInListView()
        {
            message = "This is item2",
            level = Level.Error
        };
        var item3 = new ITemInListView()
        {
            message = "This is item3",
            level = Level.Error
        };
        var item4 = new ITemInListView()
        {
            message = "This is item4",
            level = Level.Warning
        };
        list.Add(item1);
        list.Add(item2);
        list.Add(item3);
        list.Add(item4);
        //Set the width of the column to be the width of the ListView control so it expands to full size.
        lvMessages.Columns[0].Width = lvMessages.Width;
        foreach (ITemInListView item in list)
        {
            var lvi = lvMessages.Items.Add(item.message);
            switch (item.level)
            {
                case Level.Warning:
                    lvi.BackColor = Color.Yellow;
                    break;
                case Level.Error:
                    lvi.BackColor = Color.Red;
                    break;
            }
        }
