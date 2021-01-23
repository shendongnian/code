        using(StreamReader reader = new StreamReader(stream))
        {
            string line = reader.ReadLine();
            while(line != null)
            {
                searchFoldersListView.Items.Add(line);
                line = reader.ReadLine();
            }
        }
