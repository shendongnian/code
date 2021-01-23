    Console.WriteLine("Please input a word or phrase:");
    string userInput = Console.ReadLine().ToLower();
    for (int i = 0; i < userInput.Length; i++)
            {
                //c stores the index of userinput and converts it to string so it is readable and the program wont bomb out.[i]means position of the character.
                string c = userInput[i].ToString();
                if ("aeiou".Contains(c))
                {
                    vowelcount++;
                }
            }
            Console.WriteLine(vowelcount);
