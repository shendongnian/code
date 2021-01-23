        public void WriteCBValuesToFile()
        {
            foreach (Control control in this.Controls) // 'this' is the form... In your case it might be a groupBox, panel, etc.
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    if (cb.Name == "Whatever")
                    { 
                        //Whatever...
                    }
                }
            }
        }
