    // At the top of your program
    StringBuilder sb = new StringBuilder();
    // BeginningTime, BeginningDate, etc...
    // Before the first loop
    Console.WriteLine("Working...");
    // Inside the very inner if, where your Console.WriteLine was
    sb.AppendLine(MyFile.FullName);
    // After the end of the outer loop
    Console.WriteLine(sb.ToString());
   
