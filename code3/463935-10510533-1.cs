	int delimiter = line.IndexOf(':'); 
	 if(!String.IsNullOrEmpty(line) && delimiter > 0 )
		{
			int imageIndex = int.Parse(line.Substring(0, delimiter)); 
			string questionText=line.Substring(delimiter + 1); 
			pictureBox1.Image = imageList1.Images[imageIndex];  
	
			textBox1.Text = questionText;
			radioButton1.Text = questions[x].answer1;  
			questions[x].displayed= true; 
			current_question = x; 
		}
