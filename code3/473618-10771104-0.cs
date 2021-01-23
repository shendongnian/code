        List<TextBox> textBoxList = new List<TextBox>();
        //Example insert method
        public void insertTextBox(TextBox tb)
        {
            textBoxList.Add(tb);
        }
        //Example contains method
        public bool checkIfTextBoxExists(TextBox tb)
        {
            if (textBoxList.Contains(tb))
                return true;
            else
                return false;
        }
