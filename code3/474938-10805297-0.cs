      private void Textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if the enter key is pressed it triggers the submit button.
            if (e.KeyCode == Keys.Enter)
            {
                buttonSubmit_Click((object)sender, (EventArgs)e);
                
            }
        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //this is what the enter key triggers. 
            MessageBox.Show("you hit the enter key");
        }
