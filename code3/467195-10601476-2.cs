    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (MessageBox.Show("Contiue or not", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.No)
        {
            Application.Exit(); // or this.Close();
        }
    }
