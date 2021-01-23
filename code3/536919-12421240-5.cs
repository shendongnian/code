     String examplestring = @"color=**""&#x26;amp&#x3B;****amp&#x3B**;**amp&#x3B;&#x23;x23&#x3B;**336699""";
     Console.WriteLine(examplestring);
     String lastsixnumbers = examplestring.Substring(examplestring.Length - 7, 6);
     Console.WriteLine(lastsixnumbers);
     String final = String.Format("color=\"#{0}\"", lastsixnumbers);
     Console.WriteLine(final);
     Console.ReadKey();
