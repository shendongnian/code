     TabControl tbcEditor = new TabControl();
     private void frmTextEditor_Load(object sender, EventArgs e)
     {
          Controls.Add(tbcEditor);
          tbcEditor.Dock = DockStyle.Fill;
          AddMyControlsOnNewTab();
     }
    private void AddMyControlsOnNewTab()
    {
        TabPage tbPage = new TabPage();
        RichTextBox rtb = new RichTextBox();
        tbPage.Tag = rtb; //just one extra bit of line.
        tbcEditor.TabPages.Add(tbPage);
        tbPage.Controls.Add(rtb);
        rtb.Dock = DockStyle.Fill;
    }
    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        AddMyControlsOnNewTab();
    }
