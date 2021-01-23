	for (int row = 0; row < array_questions.GetLength(0); row++)
	{
		for (int column = 0; column < array_questions.GetLength(1); column++)
		{
            //writing data, you probably want to add comma after it
			Response.Write(array_questions[row,column]); 
		}
                
        //adding new line, so that next loop will start from new line
		Response.Write(Environment.NewLine);
	} 
