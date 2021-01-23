    string line = string.Empty;
    do
    {
        line = Console.ReadLine();
        if (!string.IsNullOrEmpty(line))
        { 
           numbers[i] = int.Parse(line);
           i++;
        }
        else
        {
          ok = true;
        }
    
    }while (!ok && i<10);
