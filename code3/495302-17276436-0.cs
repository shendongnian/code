            int b;
            b = Int32.Parse(textBox1.Text);
               
            int ans = (100-b)/3; //the 3 represents the interval
            //100 represents the last number
            
            switch(ans)
            {
            
               case 0:
                    MessageBox.Show("98 to 100");
               break;
               case 1:
                    MessageBox.Show("95 to 97");
               break;
               case 2:
                    MessageBox.Show("92 to 94");
               break;
               case 3:
                    MessageBox.Show("89 to 91");
               break;
               
               case 4:
                    MessageBox.Show("86 to 88");
               break;
                
               default:
                    MessageBox.Show("out of range");
               break;
