            Regex reg = new Regex("^[A-Za-z]+$");
            do
            {
                DisplayDivider("Get Name");
                strInput = GetInput("your Name");
                isValid = reg.IsMatch(strInput);
                if (!isValid)
                {
                    isValid = false;
                    Console.WriteLine("'" + strInput + "' is not a valid name entry. Please retry...");
                }
            } while (!isValid); 
