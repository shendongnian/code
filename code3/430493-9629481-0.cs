    private static string searchFile(String searchText)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader("test.txt");
            String text = reader.ReadToEnd();
            int poz = text.IndexOf(searchText);
            if (poz >= 0)
            {                
                int start = poz + searchText.Length;
                int end = text.IndexOf(Environment.NewLine, start);   
                Console.WriteLine(searchText + " was  found in the given file", "Finally!!");
                return text.Substring(start, end - start);
            }
            else
            {
                Console.WriteLine("Sorry, but " + searchText + " could not be found in the given file", "No Results");
                return string.Empty;
            }
        }
