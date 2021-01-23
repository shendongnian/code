     private void Label_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "admin") || (textBox1.Text == "admin"))
            {
                Label.Text = "right";
            }
            else
            {
                Label.Text = "wrong";
                errorProvider1.SetError(errorprovider, "Wrong Username or Password");
            }
        }
