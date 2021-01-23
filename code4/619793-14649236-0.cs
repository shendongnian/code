    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      var objects = new List<object>
                    {
                        this.ActiveMdiChild as SEdit,
                        this.ActiveControl as SoEdit,
                        this.ActiveControl as UpEdit,
                        this.ActiveControl as LEdit,
                        this.ActiveControl as CEdit
                    };
            if (objects.Any(x => x != null))
            {
                if (MessageBox.Show("Do you want to save before exit?", "Closing",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MessageBox.Show("To Do saved.", "Status",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                }
            }
         }
