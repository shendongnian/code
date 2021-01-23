    Dictionary<string, bool> clients = new Dictionary<string, bool>();
                        clients.Add("abc", true);
                        clients.Add("abc2", true);
                        clients.Add("abc3", false);
                        clients.Add("abc4", true);
        
                        bool isValid = false;
                       
                        if (clients.TryGetValue("abc3", out isValid)==false||isValid == false)
                        {
                            Console.WriteLine(isValid);
                        }
                        else
                        {
                            Console.WriteLine(isValid);
                        }
