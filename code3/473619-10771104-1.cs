        List<TextBox> textBoxList = new List<TextBox>();
        //Example insert method
        public void InsertTextBox(TextBox tb)
        {
            textBoxList.Add(tb);
        }
        //Example contains method
        public bool CheckIfTextBoxExists(TextBox tb)
        {
            if (textBoxList.Contains(tb))
                return true;
            else
                return false;
        }
