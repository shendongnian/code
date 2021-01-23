    void ws_getMenuCompleted(object sender, getMenuCompletedEventArgs e)
            {
                PivotItem pvt;
                for (int i = 0; i < e.Result.menu.Length; i++)
                {
                    pvt = new PivotItem();
                    pvt.Header = e.Result.menu[i].name.ToLower();
                    var stack = new StackPanel();
                    pvt.Content = stack;
                    pvtRestaurante.Items.Add(pvt);
                    pvt = null;
                }
    }
