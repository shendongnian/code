            bool match = true;
            foreach (string aString in stringA.Split((' ')))
            {
                if (!stringB.Contains(aString))
                {
                    match = false;
                    break;
                }
            }
