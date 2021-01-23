    }
            list = new List<string>();
        }
     
        private void BatchBoxCheckedChanged(object sender, EventArgs e)
        {
            CheckBox batchBox = (CheckBox)sender;
            //Here I want to store name of checkbox in array
            
            if (batchBox.Checked == true)
            {
                list.Add(batchBox.Text);  
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(string prime in list) // Loop through List with foreach
            {
                Console.WriteLine(prime);
            }
        }       
