                string m = "";
                StreamReader r = new StreamReader("file_path");
                while (r.EndOfStream == false)
                {
                    m = r.ReadLine();
                }
                Console.WriteLine("{0}\n", m);
                r.Close();
