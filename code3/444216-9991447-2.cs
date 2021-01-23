       TabPage tbPage = new TabPage();
        RichTextBox rtb = new RichTextBox();
        tbcEditor.TabPages.Add(tbPage);
        tbPage.Controls.Add(rtb);
        rtb.Dock = DockStyle.Fill;
    }
    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        AddMyControlsOnNewTab();
    }
