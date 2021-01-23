    void Main()
    {
    	var w = new Form();
    	var t = new TreeView();
    	w.Controls.Add(t);
    	t.Dock=DockStyle.Fill;
    	t.Nodes.Add("Star: \u2605");
    	t.Font=new System.Drawing.Font("Arial Unicode MS", 13f);
    	w.Show();
    }
