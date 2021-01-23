            string originalWord = "stack";
            // Use ToCharArray to convert string to array.                
            char[] array = originalWord.ToCharArray();
            // Loop through array.
            for (int i = 0; i < array.Length; i++)
            {
                // Get character from array.
                char letter = array[i];
                string result = originalWord.Insert(i, letter.ToString(CultureInfo.InvariantCulture));
                Console.WriteLine(result);
            }
