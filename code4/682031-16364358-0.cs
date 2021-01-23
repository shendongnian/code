    using System.Linq;
    ...    
    System.IO.File.ReadAllLines(pathToFile)
        .ToList()
        .ForEach(line => listView.Items.Add(new ListViewItem(line)));
