        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                userinputF = Int32.Parse(txtFaculteit.Text);
                for (counter = 1; counter <= userinputF; counter++)
                {
                    answer = answer *=  counter;
                }          
            }
            catch (Exception exception)
            {
                    MessageBox.Show("Please fill in a number " + exception.Message);
            }
       
            lblAnswerFaculteit.Text = lblAnswerFaculteit.Text + "The faculty of " + userinputF + " = " + answer;
        }
    }
}
