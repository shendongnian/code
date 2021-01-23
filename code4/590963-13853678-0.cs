        private void button1_Click(object sender, EventArgs e)
        {
            string where = "";
            if (cbxCompanyName.Text.Trim().Length != 0)
            {
                where += " and CompanyName='" + this.cbxCompanyName.Text + "'";
            }
            if (cbxProductName.Text.Trim().Length != 0)
            {
                where += " and ProductName='" + this.cbxProductName.Text + "'";
            }
            if (cbxDesign.Text.Trim().Length != 0)
            {
                where += " and Design='" + this.cbxDesign.Text + "'";
            }
        }
