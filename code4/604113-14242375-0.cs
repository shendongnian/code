    string path = @"D:\";
    var items = from file in new DirectoryInfo(path).EnumerateFiles()
                select new ListViewItem(new string[] {
                        Path.GetFileNameWithoutExtension(file.Name), // Name
                        Path.GetExtension(file.Name).Replace(".", ""), // Type
                        file.CreationTime.ToString()  // Date Modified               
                    });
    
    listView.Items.AddRange(items.ToArray());
