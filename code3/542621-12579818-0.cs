class unfocusableTextBox : TextBox
    {
        public unfocusableTextBox(){
               SetStyle(ControlStyles.Selectable, false);
        }
    }
