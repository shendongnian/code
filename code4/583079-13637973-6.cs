    string arrayLine = "";
  
    try
    {
        StreamReader fileReader = new StreamReader("C:\\Numbers.txt");
        string line = fileReader.ReadLine();
        while (line != null)
        {
            Console.WriteLine(line);
            if (arrayLine != "")
            {
                 arrayLine += " " + line; // Add the rest of the number lines together
            }
            else
            {
                 arrayLine = line;  // Add the first line
            }
            
            line = fileReader.ReadLine();    
        }
        fileReader.Close();
    } 
    catch (IOException IOEx)
    {
        throw new Exception("no file found");
    }
    catch (Exception ex)
    {
        throw new Exception("Other Exception found");
    }
    // Add the numbers into an array
    int[] myNumberArray = SplitStringToNumbersArray(arrayLine);
