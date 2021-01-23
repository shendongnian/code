    int index = Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.Find(findText, RichTextBoxFinds.None);
    while (index > 0)
    {
        Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.SelectionBackColor = Color.Yellow;
        index = Basic_Word_Processor.Instance.richTextBoxPrintCtrl1.Find(findText, index+1, RichTextBoxFinds.None);
    }
