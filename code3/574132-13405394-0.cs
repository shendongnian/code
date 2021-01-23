          public string GetMessage(string input)
            {
                var result = string.Empty;
                switch (input)
                {
                    case "1":
                        result = "Enter Account Number: ";
                        break;
                    case "2":
                        result = "Hello World!";
                        break;
                    default:
                        break;
                }
                return result;
            }
