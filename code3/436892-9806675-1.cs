        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ProcessRows();
            }
		}
        private  void ProcessRows()
        {
            foreach (GridViewRow oneRow in Cash_GridView.Rows)
            {
                CheckBox checkBoxControl = oneRow.FindControl("MemberCheck") as CheckBox;
                if (checkBoxControl != null && checkBoxControl.Checked)
                {
                    // You have a row with a 'Checked' checkbox.
                    // You can access other controls like I have accessed the checkbox
                    // For example, If you have a textbox named "YourTextBox":
                    TextBox textBoxSomething = oneRow.FindControl("YourTextBox") as TextBox;
                    if (textBoxSomething != null)
                    {
                        // Use the control value for whatever purpose you want.
                        // Example:
                        if (!string.IsNullOrWhiteSpace(textBoxSomething.Text))
                        {
                            int amount = 0;
                            int.TryParse(textBoxSomething.Text, out amount);
                            // Now you can use the amount for any calculation
                        }
                    }
                }
            }
        }
