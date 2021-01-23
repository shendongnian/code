                string[] names = { "James", "Bob", "Jim" };
                int[] numbers = { 0, 1, 2 };
                string[] result = new string[names.Length * 3];
                for (int i = 0, y = 0 ; i < result.Length; i+=3,y++)
                {
                    result[i] = names[y] + numbers[0].ToString();
                    result[i + 1] = names[y] + numbers[1].ToString();
                    result[i + 2] = names[y] + numbers[2].ToString();
                }
