     using (TextWriter tw = new StreamWriter(@"D:\out.txt"))
            {
                string fileContent = File.ReadAllText(@"D:\in.txt");
                string[] integerStrings = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] integers = new int[integerStrings.Length];
                for (int n = 0; n < integerStrings.Length; n++)
                {
                    integers[n] = int.Parse(integerStrings[n]);
                    tw.Write(integers[n] + " ");
                }
            }
