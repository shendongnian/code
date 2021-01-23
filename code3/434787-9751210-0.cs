            var source = new List<string>() { "this", "is", "a", "test", "to", "see", "if", "this", "is", "working" };
            var userInput = "this is a";
            var inputList = userInput.Split(' ');
            var inputListCount = inputList.Count();
            var exists = false;
            for (int i = 0; i < source.Count; i++)
            {
                if (inputList[0] == source[i])
                {
                    var found = true;
                    for (int j = 1; j < inputListCount; j++)
                    {
                        if (inputList[j] != source[j])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        exists = true;
                        break;
                    }
                }
            }
            Console.WriteLine(exists);
