    private void button1_Click(object sender, EventArgs e)
            {
                int[] ab=new int[10];
                string s = textBox1.Text;
                int j = 0;
                
              
                string [] a = (s.Split(' '));
                foreach (string  word in a)
                {
                    ab[j] = Convert.ToInt32(word);
                    j++;
                }
                
                
                for (int i = 0; i < 10; i++)
                {
                    label2.Text +=ab[i].ToString()+" ";
                }
            }
