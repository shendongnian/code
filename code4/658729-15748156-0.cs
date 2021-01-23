        //Console.Write() version
        static void RPGWrite(string write)
        {
            char[] writearray = write.ToCharArray();
            int writearraycount = writearray.Count();
            for (int x = 0; x < writearraycount; x++)
            {
                if (Console.KeyAvailable == false)
                {
                    Console.Write(Convert.ToString(writearray[x]));
                    System.Threading.Thread.Sleep(30);
                }
                else
                {
                    Console.Write(Convert.ToString(writearray[x]));
                    if (x < (writearraycount - 1))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    if (x < (writearraycount - 2))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    if (x < (writearraycount - 3))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    if (x < (writearraycount - 4))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    Console.ReadKey(true);
                }
            }           
        }
        //Console.WriteLine() version
        static void RPGWriteLine(string write)
        {
            char[] writearray = write.ToCharArray();
            int writearraycount = writearray.Count();
            for (int x = 0; x < writearraycount; x++)
            {
                if (Console.KeyAvailable == false)
                {
                    Console.Write(Convert.ToString(writearray[x]));
                    System.Threading.Thread.Sleep(30);
                }
                else
                {
                    Console.Write(Convert.ToString(writearray[x]));
                    if (x < (writearraycount - 1))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    if (x < (writearraycount - 2))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    if (x < (writearraycount - 3))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    if (x < (writearraycount - 4))
                    {
                        x++;
                        Console.Write(Convert.ToString(writearray[x]));
                    }
                    Console.ReadKey(true);
                }
            }
            Console.Write("\n");
        }
