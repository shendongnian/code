    private void button1_Click(object sender, EventArgs e)
    {
        int answer;
        if(!int.TryParse(textBox4.Text, out answer))
        {
            MessageBox.Show("Please Enter A Valid Integer.");
            return;
        }
        int x = Randomnumber.Next(12);
        int z = Randomnumber.Next(12);
    
        //int cv = +correct;
        textBox2.Text = x.ToString();
        textBox3.Text = z.ToString();
    
        int s = x * z;
        if (s == answer)
        {
            correct++;
            numbercorrect.Text = correct.ToString();
        }
    }
