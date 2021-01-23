     //shows contents of form fields
      StringBuilder MessageText = new StringBuilder();
            MessageText.AppendLine(string.Format("Coil#: {0}", coil_Num.Text));
            MessageText.AppendLine(string.Format("Location: {0}", location_box.Text));
            MessageText.AppendLine(string.Format("Sub-Area: {0}", sub_area_box.Text));
            MessageText.AppendLine(string.Format("Row: {0}", row_Num.Text));
            MessageText.AppendLine();
            MessageText.AppendLine();
    
      //asks if info is correct, with a YES/NO button and question mark
      DialogResult result1 = MessageBox.Show(MessageText.ToString() + "Information is correct?",
            "Double Check Form Information",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);
