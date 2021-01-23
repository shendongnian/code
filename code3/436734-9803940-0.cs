    var lines = File.ReadAllLines("file.csv");
    var menuStrip = new MenuStrip();
    foreach (var lineSplit in lines.Where(l => l.Trim() != string.Empty).Select(line => line.Split(',')))
    {
        var subMenu = new ToolStripMenuItem(lineSplit[0]);
        menuStrip.Items.Add(lineSplit[0]);
        for (var i = 1; i < lineSplit.Length; i++)
        {
            subMenu.DropDownItems.Add(lineSplit[i]);
        }
    }
     this.Controls.Add(menuStrip);
