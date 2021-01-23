            //string inputStr = "20130201:14:58:47 I search: xx ('ID'= (xxxxxxxx) )";
            //string inputStr = "20130201:14:58:56 I request: search | For ID | Search";
            string inputStr = "20130201:14:58:56 I search: xx ('ID'= (xxxxxxx) )";
            string dateStr = inputStr.Substring(0, 17);
            string[] splitStr = inputStr.Substring(18).Split(new char[] { ':' });
            string actionStr = splitStr[0].Substring(0, splitStr[0].IndexOf(' '));
            string userStr = splitStr[0].Substring(2);
            string restStr = splitStr[1].TrimStart();
            // print out what we parsed
            Console.WriteLine(inputStr);
            Console.WriteLine(dateStr);
            Console.WriteLine(actionStr);
            Console.WriteLine(userStr);
            Console.WriteLine(restStr);
