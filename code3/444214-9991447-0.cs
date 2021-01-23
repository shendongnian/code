            foreach (Control c in tbcEditor.SelectedTab.Controls.Controls)
            {
                if (c is RichTextBox)
                {
                    Clipboard.SetDataObject(((RichTextBox)c).SelectedText);
                    break; //assuming u have just one main rtb there
                }
            }
        }
    }
