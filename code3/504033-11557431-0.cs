            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Test", "Value1");
            dict["OtherKey"] = "Value2"; //Adds a new element in dictionary 
            Console.Write(dict["OtherKey"]);
            dict["OtherKey"] = "New Value"; // Modify the value of existing element to new value
            Console.Write(dict["OtherKey"]);
