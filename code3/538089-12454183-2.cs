     String input2 = "file*.xml";
            Regex regex = new Regex("^" + input2.Replace(".", "\\.").Replace("*",".*") + "$");
            String input1 = "file_123.xml";
            String input3 = "file_123.xml.done";
            System.Console.WriteLine(regex.IsMatch(input1));
            System.Console.WriteLine(regex.IsMatch(input3));
            System.Console.ReadLine();
    ...
