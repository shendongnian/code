     TabControl tbcEditor = new TabControl();
     private void frmTextEditor_Load(object sender, EventArgs e)
     {
          Controls.Add(tbcEditor);
          tbcEditor.Dock = DockStyle.Fill;
          AddMyControlsOnNewTab();
     }
