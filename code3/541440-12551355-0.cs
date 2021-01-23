                bool bEnteredNumberNotValid = true;
                while (bEnteredNumberNotValid)
                {
                    Console.WriteLine("Your age:");
                    string sAge = Console.ReadLine();
    
                    string regString = "(^[0-9]+$)"; //REGEX FOR ONLY NUMBERS
    
                    Regex regVal = new Regex(regString, RegexOptions.IgnoreCase | RegexOptions.Singleline); //REGEX ENGINE
                    Match matVal = regVal.Match(sAge); //REGEX MATCH WITH THE INPUT
                    if (!matVal.Success) // IF THERE IS NO MATCH, SHOW THE BELOW
                    {
                        Console.WriteLine("{0} is not an integer", sAge);
                    }
                    else // ELSE SET bEnteredNumberNotValid FALSE AND GET OUT.
                    {
                        bEnteredNumberNotValid = false;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
