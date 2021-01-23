       using(System.IO.StreamReader rdr = new System.IO.StreamReader(@"C:\text.txt"))
       {
                int counter = 0;
                string lne;
                while((lne = rdr.ReadLine()) != null)
                {
                    string[] temp = lne.Split('\t');
                    Console.WriteLine(temp[0]);
                    Console.WriteLine(temp[1]);
                    counter++;
                }
       }
       Console.ReadLine();
