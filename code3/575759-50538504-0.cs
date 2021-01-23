            try
            {
                if (Application.OpenForms.OfType<talkForm>().Any())
                {
                    talkForm frm = new talkForm();
                    frm.Close();
                    MessageBox.Show("Form is opened");
                }
                else
                {
                    talkForm frm = new talkForm();
                    frm.Show();
                    MessageBox.Show("Form is not opened");
                }
            }
            catch(Exception ex)
            {
            }
