           List<string> opt = choice.Split('\t').ToList<string>(); 
           label1.Font = new Font("Times New Roman", 15);
           label1.Text = ques;
           
           if(opt.Count >= 1)
           {
              ch1.Font = new Font("Times New Roman", 15);
              ch1.Text = opt[0];
           }
           if(opt.Count >= 2)
           {
              ch2.Font = new Font("Times New Roman", 15);
              ch2.Text = opt[1];
           }
           if(opt.Count >= 3)
           {
              ch3.Font = new Font("Times New Roman", 15);
              ch3.Text = opt[2];
           }
           if(opt.Count >= 4)
           {
              ch4.Font = new Font("Times New Roman", 15);
              ch4.Text = opt[3];
           }
