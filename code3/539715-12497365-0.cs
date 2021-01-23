        internal class MyTextBox : System.Windows.Forms.TextBox, iMyControls
        {
             public bool ValidateControl()
             {
                 return this.Text != "";
             }
        }
