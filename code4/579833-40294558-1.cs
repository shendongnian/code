            static void Main(string[] args)
            {        
                 Foo(m.Length-1);
            }
            static string m = "1234"; 
            static string c = "3456"; 
            static int ctr = 0;
            static void Foo(int arg)
            {
                if (arg >= 0)
                {
                    Foo(arg - 1);
                    Console.Write(m[arg].ToString());
                    for (int i = ctr; i <  m.Length; i++)
                    {
                        if (c[i].ToString() == m[arg].ToString())
                        {
                            ctr++;
                            break;
                        }
                    }  
                    if(arg==m.Length-1)
                    {
                        for (int i = ctr; i <m.Length; i++)
                        {
                            Console.Write(c[i].ToString());
                        }
                    }
                }
             }
