     private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            int flag = 0;
            string u, p;
            u = textBox1.Text;
            p = textBox2.Text;
            if(u=="username" && p=="pasword")
            {
                flag = 1;
            }
            else
            {
              MessageBox.Show("enter correct details");
            }
            if(flag==1)
            {
                f2.Show();
                this.Hide();
            }
        }
