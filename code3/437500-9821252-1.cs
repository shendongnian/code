    public void ClearTextBox(params System.Web.UI.WebControls.TextBox[] textBoxes)
    {
       foreach(System.Web.UI.WebControls.TextBox textBox in textBoxes)            
           textBox.Text = "";
    }
