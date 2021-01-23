    private void LoadEditorTab()
        {
            var editor = new PcmEditorForm();
            var grid = new GridView();
            grid.Anchor= AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            editor.Controls.Add(grid);
            tabEdit.Controls.Clear();
            editor.TopLevel = false;
            editor.Visible = true;
            editor.dock=DockStyle.Fill;
            tabEdit.Controls.Add(editor);
        }
