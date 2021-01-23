    private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
      {
         DialogResult result = MessageBox.Show("EXIT?", "Exit Program", MessageBoxButtons.YesNo);
    
         if (result != DialogResult.Yes)
         {
              e.Cancel = true;
         }
      }
