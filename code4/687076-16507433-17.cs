    private void DateStamp()
    {
        if (dateFormat.ToUpper() == "DD/MM/YYYY")
        {
            int CaretPosition = richTextBoxPrintCtrl1.SelectionStart;
            string TextBefore = richTextBoxPrintCtrl1.Text.Substring(0, CaretPosition);
            string textAfter = richTextBoxPrintCtrl1.Text.Substring(CaretPosition);
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            richTextBoxPrintCtrl1.SelectedText = currentDate;
        }
        else if (dateFormat.ToUpper() == "MM/DD/YYYY")
        {
            int CaretPosition = richTextBoxPrintCtrl1.SelectionStart;
            string TextBefore = richTextBoxPrintCtrl1.Text.Substring(0, CaretPosition);
            string textAfter = richTextBoxPrintCtrl1.Text.Substring(CaretPosition);
            string currentDate = DateTime.Now.ToString("MM-dd-yyyy");
            richTextBoxPrintCtrl1.SelectedText = currentDate;
        }
        else if (dateFormat.ToUpper() == "YYYY/DD/MM")
        {
            int CaretPosition = richTextBoxPrintCtrl1.SelectionStart;
            string TextBefore = richTextBoxPrintCtrl1.Text.Substring(0, CaretPosition);
            string textAfter = richTextBoxPrintCtrl1.Text.Substring(CaretPosition);
            string currentDate = DateTime.Now.ToString("yyyy-dd-MM");
            richTextBoxPrintCtrl1.SelectedText = currentDate;
        }
        else if (dateFormat.ToUpper() == "YYYY/MM/DD")
        {
            int CaretPosition = richTextBoxPrintCtrl1.SelectionStart;
            string TextBefore = richTextBoxPrintCtrl1.Text.Substring(0, CaretPosition);
            string textAfter = richTextBoxPrintCtrl1.Text.Substring(CaretPosition);
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            richTextBoxPrintCtrl1.SelectedText = currentDate;
        }
    }
