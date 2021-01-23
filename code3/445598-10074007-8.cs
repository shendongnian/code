    private void button1_Click_1(object sender, EventArgs e) 
     { 
        if (nr > questions.Count) 
        { 
            button1.Enabled = false; 
        } 
        else 
        { 
            Random r = new Random(); 
            int x; 
            do   { x = r.Next(questions.Count); }  
                  while (questions[x].displayed == true); 
            string line = questions[x].text; 
            int delimiter = line.IndexOf(':'); 
            int imageIndex = int.Parse(line.Substring(0, delimiter)); 
            string questionText=line.Substring(delimiter + 1); 
            pictureBox1.Image = imageList1.Images[imageIndex];//I still have problems with        
            textBox1.Text = questionText;// now it doesn't appear the index;thank you 
            radioButton1.Text = questions[x].answer1; // is not from the current 
                                                      //  question 
            radioButton2.Text = questions[x].answer2;// is not from the current 
                                                     //  question 
            questions[x].displayed= true; 
            current_question = x; 
        } 
      } 
