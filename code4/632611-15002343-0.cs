            String textInput = "11,11A,12,12A,13-16,18,22-30";
            String[] strArray = textInput.Split(',');
            List<String> pages = new List<String>();
            foreach (String s in strArray)
            {
                String[] range = s.Split('-');
                if (range.Length == 2)
                {
                    int startPage = int.Parse(range[0]);
                    int endPage = int.Parse(range[1]);
                    for (int i = startPage; i<= endPage; i++)
                    {
                        pages.Add(i.ToString());
                        pages.Add(i.ToString()+"A");
                    }
                }
                else
                {
                    pages.Add(s);
                }
            }
            String[] resultArray = pages.ToArray();
            Console.WriteLine("Input: " + textInput);
            foreach (String s in resultArray)
            {
                Console.WriteLine(s);
            }
