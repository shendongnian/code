    String str = "A\nB\nC\nD\nE\nF\nG\nH\nI";
                List<String> myList = str.Split(new Char[]{'\n'}, 5, StringSplitOptions.RemoveEmptyEntries).ToList<String>();
                myList[myList.Count - 1] = myList[myList.Count - 1].Split(new Char[] { '\n' })[0];
                System.Console.WriteLine(myList.Count);
                foreach (String str1 in myList)
                {
                    System.Console.WriteLine(str1);
                }
                System.Console.Read();
