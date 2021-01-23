    static void Main(string[] args)
            {
                var testEnumeration = SomeEnum.Val3;
    
                if (testEnumeration == SomeEnum.Val1)
                    Console.WriteLine("1");
                else if (testEnumeration == SomeEnum.Val2)
                    Console.WriteLine("2");
                else if (testEnumeration == SomeEnum.Val3)
                    Console.WriteLine("3");
                else if (testEnumeration == SomeEnum.Val4)
                    Console.WriteLine("4");
    
                switch (testEnumeration)
                {
                    case SomeEnum.Val1:
                        { Console.WriteLine("1"); break;}
                    case SomeEnum.Val2:
                        { Console.WriteLine("2"); break; }
                    case SomeEnum.Val3:
                        { Console.WriteLine("3"); break; }
                    case SomeEnum.Val4:
                        { Console.WriteLine("4"); break; }
                }
    
            }
