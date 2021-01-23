    void Main()
    {
    	string datePrompt = "Please enter the date mm/dd/yyyy: ";
    	string invalidDateMessage = "Invalid date format, please use mm/dd/yyyy, for example you could type 01/07/1980.";
    	
    	DateTime dateTime;
    	bool done = false;
    	while(!done)
    	{
    		string userInput = Prompt(datePrompt, Console.Out, Console.In);
    		done = ValidateAndParseDate(userInput, out dateTime, Console.Out, invalidDateMessage);
    	}
        Console.WriteLine("I can now store {0} in a multi dimensional array!", dateTime.ToShortDateString());
    }
    
    string Prompt(string prompt, TextWriter writer, TextReader reader)
    {
    	writer.Write(prompt);
    	string line = reader.ReadLine();
    	return line;
    }
    
    bool ValidateAndParseDate(string dateString, out DateTime dateTime, TextWriter writer, string errorMessage)
    {
    	bool isValid = DateTime.TryParseExact(
    								dateString,
    								"MM/dd/yyyy",
    								CultureInfo.InvariantCulture,
    								DateTimeStyles.None,
    								out dateTime);
    								
    	if(!isValid)
    	{
    		writer.WriteLine(errorMessage);
    	}
    	return isValid;
    }
