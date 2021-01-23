    try
    {
        var fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/textme.txt";
        var lines = AnimalShelter.AnimalList.Select(o=> "<chipNr>" + o.ChipRegistrationNumber + "</chipNr>");
    	File.WriteAllLines(fileName, lines);
        foreach(var line in lines)
            Console.WriteLine(line);
    }
    catch(IOException)
    {
        MessageBox.Show("ERROR THROWN");
    }
