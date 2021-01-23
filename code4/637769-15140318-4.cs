    private void collectg_Click(object sender, EventArgs e)
    {
        if (_hasBoys)        
            return;        
        _hasBoys = true;
        listBox1.DataSource = File.ReadAllLines(@"C:\Path\tofile\girls.txt")
                                  .Select(line => new Girl { Name = line })
                                  .ToList();
    }
    private void collectb_Click(object sender, EventArgs e)
    {
        if (_hasGirls)
            return;
        _hasGirls = true;
        listBox1.DataSource = File.ReadAllLines(@"C:\Path\tofile\boys.txt")
                                  .Select(line => new Boy { Name = line })
                                  .ToList();
    }
