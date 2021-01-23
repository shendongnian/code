            var items = new List<string>();
            items.Add("1");
            items.Add("2");
            items.Add("3");
            var results = items.Skip(1).Take(1).ToList();
            MessageBox.Show(results[0]);
