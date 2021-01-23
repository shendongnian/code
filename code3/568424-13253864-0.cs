            var lst = new  ListView();
                for (int i = lst.Items.Count - 1; i >= 0; i--)
            {
                var itemtoremove = //Put your condition here and get that item
                lst.Items.Remove(lst.Items.Find("key"));
            }
