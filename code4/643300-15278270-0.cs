            string text = System.IO.File.ReadAllText(@"writeText.txt");
            int[] arr = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                arr[i] = Convert.ToInt32(text[i].ToString());
            }
