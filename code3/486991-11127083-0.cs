        protected override void OnLoad(EventArgs e)
	    {
			CreateColumns(treeList1);
			CreateNodes(treeList1);
			treeList1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			treeList1.OptionsBehavior.AutoNodeHeight = true;
            base.OnLoad(e);
	    }
		private void CreateColumns(TreeList tl)
		{
			// Create three columns.
			tl.BeginUpdate();
			tl.Columns.Add();
			tl.Columns[0].Caption = "Customer";
			tl.Columns[0].VisibleIndex = 0;
			tl.Columns.Add();
			tl.Columns[1].Caption = "Location";
			tl.Columns[1].VisibleIndex = 1;
			tl.Columns.Add();
			tl.Columns[2].Caption = "Phone";
			tl.Columns[2].VisibleIndex = 2;
			tl.Columns[0].ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			tl.EndUpdate();
		}
		private void CreateNodes(TreeList tl)
		{
			tl.BeginUnboundLoad();
			// Create a root node .
			TreeListNode parentForRootNodes = null;
			TreeListNode rootNode = tl.AppendNode(
				new object[] { "Alfreds FutterkisteTEST\r\nTEST\r\nTEST", "Germany, Obere Str. 57", "030-0074321" },
				parentForRootNodes);			
			// Create a child of the rootNode
			tl.AppendNode(new object[] { "Suyama, Michael", "Obere Str. 55", "030-0074263" }, rootNode);
			// Creating more nodes
			// ...
			tl.EndUnboundLoad();
		}
