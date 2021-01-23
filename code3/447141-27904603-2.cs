    private Aga.Controls.Tree.TreeViewAdv _treeViewAdv;
    private Aga.Controls.Tree.TreeColumn Column1;
    private Aga.Controls.Tree.TreeColumn Column2;
    private Aga.Controls.Tree.TreeColumn Column3;
    private Aga.Controls.Tree.NodeControls.NodeTextBox NodeControl1;
    private Aga.Controls.Tree.NodeControls.NodeTextBox NodeControl2;
    private Aga.Controls.Tree.NodeControls.NodeTextBox NodeControl3;
    private InitializeComponent()
    {     
        // Left out all other initialization, since this was long enough already.
        this.treeViewAdvPrint = new Aga.Controls.Tree.TreeViewAdv();
        this.Column1 = new Aga.Controls.Tree.TreeColumn();
        this.Column2 = new Aga.Controls.Tree.TreeColumn();
        this.Column3 = new Aga.Controls.Tree.TreeColumn();
        this.NodeControl1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
        this.NodeControl2 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
        this.NodeControl3= new Aga.Controls.Tree.NodeControls.NodeTextBox();
        // 
        // _treeViewAdv
        // 
        this._treeViewAdv.BackColor = System.Drawing.SystemColors.Window;
        this._treeViewAdv.Columns.Add(this.Column1);
        this._treeViewAdv.Columns.Add(this.Column2);
        this._treeViewAdv.Columns.Add(this.Column3);
        this._treeViewAdv.DefaultToolTipProvider = null;
        this._treeViewAdv.DragDropMarkColor = System.Drawing.Color.Black;
        this._treeViewAdv.GridLineStyle = ((Aga.Controls.Tree.GridLineStyle)((Aga.Controls.Tree.GridLineStyle.Horizontal | Aga.Controls.Tree.GridLineStyle.Vertical)));
        this._treeViewAdv.LineColor = System.Drawing.SystemColors.ControlDark;
        this._treeViewAdv.Location = new System.Drawing.Point(12, 12);
        this._treeViewAdv.Model = null;
        this._treeViewAdv.Name = "_treeViewAdv";
        this._treeViewAdv.NodeControls.Add(this.Form);
        this._treeViewAdv.NodeControls.Add(this.background);
        this._treeViewAdv.NodeControls.Add(this.copy);
        this._treeViewAdv.SelectedNode = null;
        this._treeViewAdv.Size = new System.Drawing.Size(443, 356);
        this._treeViewAdv.TabIndex = 6;
        this._treeViewAdv.Text = "_treeViewAdv";
        this._treeViewAdv.UseColumns = true;
        // 
        // Column1
        // 
        this.Column1.Header = "Column 1";
        this.Column1.SortOrder = System.Windows.Forms.SortOrder.None;
        this.Column1.TooltipText = null;
        this.Column1.Width = 290;
        // 
        // Column3
        // 
        this.Column3.Header = "Column 3";
        this.Column3.SortOrder = System.Windows.Forms.SortOrder.None;
        this.Column3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Column3.TooltipText = null;
        // 
        // Column2
        // 
        this.Column2.Header = "Column 2";
        this.Column2.SortOrder = System.Windows.Forms.SortOrder.None;
        this.Column2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Column2.TooltipText = null;
        this.Column2.Width = 91;
        // 
        // NodeControl1
        // 
        this.NodeControl1.DataPropertyName = "NodeControl1";
        this.NodeControl1.IncrementalSearchEnabled = true;
        this.NodeControl1.LeftMargin = 3;
        this.NodeControl1.ParentColumn = this.Column1;
        // 
        // NodeControl2
        // 
        this.NodeControl2.DataPropertyName = "NodeControl2";
        this.NodeControl2.IncrementalSearchEnabled = true;
        this.NodeControl2.LeftMargin = 3;
        this.NodeControl2.ParentColumn = this.Column2;
        // 
        // NodeControl3
        // 
        this.NodeControl3.DataPropertyName = "NodeControl3";
        this.NodeControl3.IncrementalSearchEnabled = true;
        this.NodeControl3.LeftMargin = 3;
        this.NodeControl3.ParentColumn = this.Column3;
    }
