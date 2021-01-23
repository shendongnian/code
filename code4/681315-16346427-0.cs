    protected void Page_Load(object sender, EventArgs e)
    {
        var tblTextboxes = new Table();
        for (int i = 0; i < 10; i++)
        {
            var tr = new TableRow();
            var tc = new TableCell();
            var tb = new TextBox {ID = i.ToString()};
            tc.Controls.Add(tb);
            tr.Cells.Add(tc);
    
            var tc1 = new TableCell();
            // This is a fix for - lnk.ID=i.ToString()+tb.Text+"lnk";
            var lnk = new LinkButton {ID = i + "lnk", Text = "Show"};
            lnk.Click += lnk_Click;
            tc1.Controls.Add(lnk);
    
            tr.Cells.Add(tc1);
    
            tblTextboxes.Rows.Add(tr);
        }
        placeTest.Controls.Add(tblTextboxes);
    }
    
    void lnk_Click(object sender, EventArgs e)
    {
        var lnk = sender as LinkButton;
        var lbl = new Label();
        lbl.Text = "LinkButton ID: " + lnk.ID;
    
        // Get number value from string
        string id = Regex.Replace(lnk.ID, @"[^\d]", "");
        // Retrieves a TextBox control by ID    
        var control = FindControlRecursive(Page, id);
    
        if (control != null)
        {
            var textbox = control as TextBox;
            lbl.Text += "; TextBox Text: " + textbox.Text;
        }
    
        placeTest.Controls.Add(lbl);
    }
    
    public Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id)
            return root;
    
        return root.Controls.Cast<Control>()
            .Select(c => FindControlRecursive(c, id))
            .FirstOrDefault(c => c != null);
    }
