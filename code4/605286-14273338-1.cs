    TreeView treeview = new TreeView();
    // Get all the <Name> elements
    XDocument doc = XDocument.Parse(xmlAsString);
    var mailboxNames = doc.Element("Response").Element("Data").Element("Settings").Element("SettingsXml").Element("ScanJobs").Element("ScanJobsData").Elements("Mailboxes").Select(m => m.Element("Name"));
            
    // Extract the email and db in each <Name> element
    foreach (var name in mailboxNames)
    {
        var namesSplit = name.Value.Split('|');
        var email = namesSplit[0];
        var db = namesSplit[1];
        // Create new db node if it not exists and add the email there
        if (!treeview.Nodes.ContainsKey(db))
        {
            TreeNode[] emails = new TreeNode[] { new TreeNode(email) };
            TreeNode node = new TreeNode(db, emails);
            treeview.Nodes.Add(node);
        }
        // If db node already exists, add email to currently existing node
        else
        {
            treeview.Nodes[db].Nodes.Add(email);
        }
    }
