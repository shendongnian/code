    public ucA : UserControl
    {
        public string myTextBoxText 
        { 
            get 
            {
                return ((TextBox)Controls.FindControl("myTextBox")).Text;
            }
        }
        /*And lot of controls*/
    }
