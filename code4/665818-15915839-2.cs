    string findText = textBox1.Text;
    string currentText = Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.Text;
    int index = currentText.IndexOf(findText, StringComparison.InvariantCultureIgnoreCase);
    while (index >= 0)
    {
        Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.Find(findText, index, currentText.Length, RichTextBoxFinds.None);
        Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.SelectionBackColor = Color.Yellow;
        index = currentText.IndexOf(findText, index+1, StringComparison.InvariantCultureIgnoreCase);
    }
    
