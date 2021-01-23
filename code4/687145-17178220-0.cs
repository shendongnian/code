       private void checkBox2_CheckedChanged(object sender,EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox.Text = (((object[])(sender))[0]).ToString();
            }
        }
