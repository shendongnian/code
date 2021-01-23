    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue=="11")
            {
                lblQuestionResult2.ForeColor = System.Drawing.Color.Green;
                lblQuestionResult2.Text = "Correct";
            }
            else
            {
                lblQuestionResult2.ForeColor = System.Drawing.Color.Red;
                lblQuestionResult2.Text = "Incorrect";
            }
        }
