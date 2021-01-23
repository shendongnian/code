    Public System.Collections.Generic.List<string> Text { 
        get {
            System.Collections.Generic.List<string> returnValue = new string[textBoxCount];
            foreach (Control ctrl in this.Controls)
                if (ctrl.GetType() == typeof(TextBox))
                    returnValue.Add(((TextBox)ctrl).Text);
            return returnValue;
       }
    }
