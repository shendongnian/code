            var total = 0;
            var sentence = "Hello, I'm Chris";
            foreach (char c in sentence.ToLower())
            {
                switch (c)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        total++;
                        break;
                    default: continue;
                }
            }
            Console.WriteLine(total.ToString());
