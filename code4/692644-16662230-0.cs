        private void button1_Click(object sender, EventArgs e)
        {
            lblCheck.Visible = false;
            lblCross.Visible = false;
            if (CheckConfiguration())
            {
                lblCheck.Visible = true;
            }
            else
            {
                lblCross.Visible = true;
            }
        }
