    // Read string from console
            string line = Console.ReadLine(); 
            int valueInt;
            float valueFloat;
            if (int.TryParse(line, out valueInt)) // Try to parse the string as an integer
            {
                Console.Write("This input is of type Integer.");
            }
            else if (float.TryParse(line, out valueFloat)) 
	        {
                Console.Write("This input is of type Float.");
	        }
            else
            {
                Console.WriteLine("This input is of type string.");
            }
