    var lines = File.ReadAllLines("file.csv");
    var menuStrip = new MenuStrip();
    // This:
    //
    // foreach (var line in lines)
    // {
    //     if (line.Trim() == string.Empty) { continue; }
    //     var lineSplit = line.Split(',');
    //
    // Is the same as:
    //
    foreach (var lineSplit in lines.Where(l => l.Trim() != string.Empty).Select(line => line.Split(',')))
    {
    //
        var subMenu = new ToolStripMenuItem(lineSplit[0]);
        menuStrip.Items.Add(subMenu);
        for (var i = 1; i < lineSplit.Length; i++)
        {
            subMenu.DropDownItems.Add(lineSplit[i]);
        }
    }
     this.Controls.Add(menuStrip);
