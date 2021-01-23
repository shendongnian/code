    string inputDate = int.Parse(textBox54.Text)+"-"+int.Parse(textBox53.Text)+"-"+int.Parse(textBox52.Text);
    DateTime dateOfBirth ;
    if (DateTime.TryParse(inputDate , out dateOfBirth ))
	{
	    //do whatever with dateOfBirth 
	}
	else
	{
	    Console.WriteLine("Invalid Date"); // <-- Control flow goes here
	}
