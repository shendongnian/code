            var items = listBox.SelectedItems;
            foreach (var item in items)
            {
                string fileName = listBox.GetItemText(item);
                string fileContents = System.IO.File.ReadAllText(fileName);
                //Do something with the file contents
            }
