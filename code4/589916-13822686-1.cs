           foreach (string str in part)
            {
                List<string> hasBeenPlaced = Put(first, str);
                foreach (string str2 in hasBeenPlaced)
                {
                    Result.Add(str2);
                }
                break;
            }
