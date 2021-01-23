    class Humanresources : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Administraror.Humanresource.EmployeeTransferForm emptranfrm = new Administraror.Humanresource.EmployeeTransferForm();
            emptranfrm.GetSampleTextFromTextBox += new EmployeeTransferForm.GetTextHandler(GetSampleTextFromTextBox_EventHandler);
            emptranfrm.ShowDialog();
        }
        Text GetSampleTextFromTextBox_EventHandler()
        {
            return myTextBox.Text;
        }
        
        //the rest of the code in the class
        //...
    }
