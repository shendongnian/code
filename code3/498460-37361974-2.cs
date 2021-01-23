    private bool checkReadOnly(Control Ctrl)
            {
                bool isReadOnly = false;
                if(((TextBox)Ctrl).ReadOnly == true)
                {
                    isReadOnly = true;
                }
                else
                {
                    isReadOnly = false;
                }
                return isReadOnly;
            }
