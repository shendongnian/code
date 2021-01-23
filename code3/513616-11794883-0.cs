            string[] array = new string[3]; //create array
            for (int i = 0; i < 5; i++)
            {
                if (array.Length-1 < i) //checking for the available length
                {
                    Array.Resize(ref array, array.Length + 1); //when to small, create a new index
                }
                array[i] = i.ToString(); //add an item to array[index] - of i
            }
