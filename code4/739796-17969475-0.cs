        private void cbalpha_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operatorcheckbox =(CheckBox)sender;
            foreach (Control cb in this.Controls)
            {
               if ((StringtDataChoiceorSelect.SelectedItem != "(Initiate)")
               {
                   if(!cb.Enabled)
                   {
                      cb.Enabled = true;
                   }
               }
               else
               {
                   cb.Enabled = false;
               }
            }
        }
