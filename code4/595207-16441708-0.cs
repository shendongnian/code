	public class ContactBase : Form
    {
        public void ReceiveValue(string p_Value)
        {
            Button button = (Button)this.Controls["lblRecordID"];
            if (button == null) return;
            button.Text = p_Value;
        }
    }
    private void OpenCompanyInformationForm(Form name)
        {
            bool isOpen = false;
    
            foreach (Form f in Application.OpenForms)
            {
    			// Just to compare, you can use the Name property
      ->		if (f.Name == name.Name)
                {
                    isOpen = true;
    				// If the message is just a name of form, you can use Name or Text property
    				// in this case you can supress message param
      ->            MessageBox.Show("The " + f.Text + " list is already open.", "INFORMATION", MessageBoxButtons.OK);
                    f.BringToFront();
    				// If the ReceiveValue is just to pass the text of lblCompanyID for lblRecordID button, you can use the function here
      ->            ((ContactBase)name).ReceiveValue(lblCompanyID.Text);
                    break;
                }
            }
    
            if (!isOpen)
            {
       ->->->   ContactBase contact = (ContactBase)Activator.CreateInstance(name.GetType());
                contact.MdiParent = this.MdiParent;
                contact.ReceiveValue(lblCompanyID.Text);
                contact.StartPosition = FormStartPosition.Manual;
                contact.Location = new Point(100, 100);
                contact.Show();
            }
    
            else
            {
                //do nothing
            }
        }
