            bool valid = true;
            for (int i = ListWords.Count - 1; i +1< ListWords.Count; i++)
            {
                if (!IsValidFollower(ListWords[i], ListWords[i + 1]))
                {
                    valid = false;
                    break;
                }
            }
