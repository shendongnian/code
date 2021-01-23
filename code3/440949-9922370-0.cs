        ContextMenu emptyMenu = new ContextMenu();
            this.components.Add(emptyMenu);
        
        private void gridView1_ShownEditor(object sender, System.EventArgs e) {
            DevExpress.XtraGrid.Views.Grid.GridView view = 
                               sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if(!view.IsFilterRow(view.FocusedRowHandle)) return;
            view.ActiveEditor.ContextMenu = emptyMenu;
        }
