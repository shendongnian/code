    public void button1_Click(object sender, EventArgs e)
    {
        VerifyAnswer();
    }
    // NOTE: static modifier removed
    private void tb_KeyDown(object sender, KeyEventArgs e) 
    {
        if (e.KeyCode == Keys.Enter)        
            VerifyAnswer();
    }
    private void VerifyAnswer()
        string tAns = textBox1.Text;
        int answer = n1 * n2;
        string tOrgAns = answer.ToString();
        if (tAns == tOrgAns)
            MessageBox.Show("Your answer is Corect", "Result", MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
        else
            MessageBox.Show("Your answer is WRONG", "Result", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        textBox1.Text = "";
        textBox1.Focus();
        tQuestion();
    }   
