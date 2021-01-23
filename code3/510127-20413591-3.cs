    private void selectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DialogResult res = MessageBox.Show(this, "click yes for english and no for hebrew", "Select language", MessageBoxButtons.YesNoCancel);
        if (DialogResult.Yes == res)
        {
            Language = "English";
        }
        else if (DialogResult.No == res)
        {
            Language = "Hebrew";
        }
        dbCon = new CDBConnector("****\\lang" + Language + ".xml");
        view.initialView();
    }
