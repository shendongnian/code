            if (int.TryParse(txtDepartmentNo.Text, out checkNumber) == false)
            {
                lblMessage.Text = string.Empty;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Maroon;
                lblMessage.Text = "You have not entered a number";
                return;
            }
