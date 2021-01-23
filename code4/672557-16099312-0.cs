    Console.WriteLine("Please enter the path to the input file:");
    string inp = Console.ReadLine();
    Console.WriteLine("Please enter the name of the new file:");
    string otp = Console.ReadLine();
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    string inputLines = System.IO.File.ReadAllLines(inp);
     for (int i = 0; i < inputLines.Length; i++)
         sb.Append("Some Text" + inputLines[i] + Environment.NewLine);
    File.WriteAllText(otp, sb.ToString())
