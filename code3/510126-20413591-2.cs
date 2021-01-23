    public void initialView()
    {
        //Set rightToLeft values
        initialIndent(mainForm);
        //set visual text values
        initialTxt();
    }
    private void initialTxt()
    {
        // Are there any more controls under mainObj (Form1)?
        Boolean endOfElemsUnderPnl = false;
        // The current Control im working on
        Object curObj = mainForm;
        do
        {
            // MenuStrip needs to be handled separately
            if (typeof(MenuStrip).ToString().Equals(curObj.GetType().ToString()))
            {
                foreach (ToolStripMenuItem miBase in ((MenuStrip)(curObj)).Items)
                {
                    miBase.Text = mainForm.dbCon.getData(miBase.Name.ToString());
                    foreach (ToolStripMenuItem miInnerNode in miBase.DropDownItems)
                    {
                        miInnerNode.Text = mainForm.dbCon.getData(miInnerNode.Name.ToString());
                    }
                }
            }
            // Any other Control i have on the form
            else
            {
                ((Control)(curObj)).Text = mainForm.dbCon.getData(((Control)(curObj)).Name.ToString());
            }
            curObj = mainForm.GetNextControl(((Control)(curObj)), true);
            // Are there any more controls under mainObj?
            if (null == curObj)
            {
                endOfElemsUnderPnl = true;
            }
        } while (!endOfElemsUnderPnl);
    }
    private void initialIndent(frmMyFileManager parent)
    {
        if (parent.Language.Equals("Hebrew"))
        {
            parent.RightToLeft = RightToLeft.Yes;
        }
        else if (parent.Language.Equals("English"))
        {
            parent.RightToLeft = RightToLeft.No;
        }
        else
        {
            parent.RightToLeft = RightToLeft.No;
        }
    }
