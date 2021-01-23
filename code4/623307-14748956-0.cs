    private void button1_Click(object sender, EventArgs e)
        {     
            if (txtBox1.Tag is int)
            {
                int a = (int)txtBox1.Tag;
                a++;
    
                txtBox1.Tag = a;
    
                txtBox1.Text = a.ToString();
            }
            else
            {
                txtBox1.Tag = 100;
                txtBox1.Text = 100;
            }
    }
