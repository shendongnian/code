    int i=0;
        while (i < line.Length)
           {
                if (line[i] != ' ')
               {
                   numbers[numCount] = "";
                   while (line[i] != ' ')
                   {
                     
                       numbers[numCount] += line[i];
                       i++;
                       if (i >= line.Length) break;
                   }
                   numCount++;
               }
               i++;
           }
            for (int ui = 0; ui < 8; ui++)
           {
               task[ui] = Convert.ToDouble(numbers[ui]);
           }
           counter++;
           Console.WriteLine("The array contain:");
           for (int ui = 0; ui < 8; ui++)
               Console.WriteLine(task[ui]);
