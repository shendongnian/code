        string[] newArray = new string[3];
        for (int i = 0, j = 0; i < 5; i++)
        {
            if (test[i].Contains("world"))
            {
                newArray[j++] = test[i];
                if (j >= newArray.Length)
                    break;
            }
        }
