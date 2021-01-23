     private void someEvent(object sender, EventArgs e)
     {           
            foreach (Control c in tbcEditor.SelectedTab.Controls)
            {
                if (c is RichTextBox)
                {
                    Clipboard.SetDataObject(((RichTextBox)c).SelectedText);
                    break; //assuming u have just one main rtb there
                }
            }
     }
