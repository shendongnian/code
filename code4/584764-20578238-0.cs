                    using (StreamReader sr = new StreamReader("Example.txt"))
                    {
                        bool done = false;
                        while (done == false)
                        {
                            string readLine = sr.ReadLine();
                            if (readLine.Contains("text"))
                            {
                                //do stuff with your string
                                Console.WriteLine("readLine");
                                sr.Close();
                                done = true;
                            }
                        }
                    }
