    private void AskToSave()
        {
           
            DialogResult result = MessageBox.Show("Save Document?", "Wait!",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                return;
            }
            else
            {
                SaveDocument();
            }
            
        }
