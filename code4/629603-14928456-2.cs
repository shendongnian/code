     private void button1_Click(object sender, EventArgs e)
        {
            List<String> testList2= new List<String>();
    
            testList2.Add(textBox1.Text);
            testList2.Add(textBox2.Text);
            testList2.Add(textBox3.Text);
            testList2.Add(textBox4.Text);
    
            textBox5.Text = testList2.Count.ToString();
    
            foreach (String val in testList2)
            {      
                textBox6.AppendText(val);
            }
            
            for (int i = 0; i < testList2.Count; i++)
            {
                textBox7.AppendText(testList2.get(i));
            }
        }
    }
