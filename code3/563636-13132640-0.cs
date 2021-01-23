	var rand = new Random();
	
	int roll1 = rand.Next(6) + 1;
	int value = 100;
	int sum = roll1 * value;
	
	totalmoneyLabel.Text = (int.Parse(totalmoneyLabel.Text) + sum).ToString("c");
	
	var images = new Dictionary<int, ImageFileMachine>
	{
		{ 1,  drios1_Project2.Properties.Resources._1Die },
		{ 2,  drios1_Project2.Properties.Resources._2Die },
		{ 3,  drios1_Project2.Properties.Resources._3Die },
		{ 4,  drios1_Project2.Properties.Resources._4Die },
		{ 5,  drios1_Project2.Properties.Resources._5Die },
		{ 6,  drios1_Project2.Properties.Resources._6Die },
	};
	
	diceBox1.Image = images[roll1];
