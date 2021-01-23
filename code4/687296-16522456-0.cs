        bool IsCancelBtnClicked = false;
        private void EmployeeIDtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (EmployeeIDtextBox.Text == "")
            {
                MessageBox.Show("Please Enter EmployeeID.", "Invalid EmployeeID");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            IsCancelBtnClicked = true;
            EmployeeIDtextBox.Validating -= new CancelEventHandler(textBox4_Validating);
            this.Close();
        }      
