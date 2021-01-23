    public class CustomRTB:RichTextBox
        {
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
    
                if ((keyData == (Keys.Control | Keys.V)))
                {
                    IDataObject iData = Clipboard.GetDataObject();
    
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        string contents = Clipboard.GetText();
                        // string newText = *process text here*
                        Clipboard.SetData(DataFormats.Text, newText);
                        this.Paste();
                        Clipboard.SetData(DataFormats.Text, contents);
                    }
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
    
        }
