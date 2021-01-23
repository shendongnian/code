    dateOfBirth = new DateTime(int.Parse(textBox54.Text), int.Parse(textBox53.Text),  int.Parse(textBox52.Text));
    DateTime dateTime2;
    if (DateTime.TryParse(dateOfBirth, out dateTime2))
	{
	    //do whatever with dateTime2
	}
	else
	{
	    Console.WriteLine("Invalid Date"); // <-- Control flow goes here
	}
