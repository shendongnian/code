            var result = new string('_', word.Length).ToCharArray();
            do
            {
                char guess = char.Parse(Console.ReadLine());
                for (var i = 0; i < word.Length; ++i)
                {
                    if(word[i] == guess)
                    {
                        result[i] = guess;
                    }
                }
                Console.WriteLine(new string(result));
            }
            //If my word contains A "_" i will keep looping
            while (result.Contains('_') && --tries != 0); 
