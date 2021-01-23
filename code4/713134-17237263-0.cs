     Console.WriteLine(@"Select one of the following option:                                
                                1-Write Applications XML
                                2-Write Drivers XML
                                3-Write Operating Systems XML
                                4-Write Packages XML
                                5-All the above
                                6-Exit");
               string strReadKey = Console.ReadKey().KeyChar.ToString();
               int.TryParse(strReadKey, out selectionKey);
               while (true)
               {
               
               switch (selectionKey)
               {                       
                   case 1:
                       DoApplications(reqObj);
                       strReadKey = Console.ReadKey().KeyChar.ToString();
                       int.TryParse(strReadKey, out selectionKey);
                       break;
                   case 2:
                       DoDrivers(reqObj);
                       strReadKey = Console.ReadKey().KeyChar.ToString();
                       int.TryParse(strReadKey, out selectionKey);
                       break;
                   case 3:
                       DoOperatingSystems(reqObj);
                       strReadKey = Console.ReadKey().KeyChar.ToString();
                       int.TryParse(strReadKey, out selectionKey);
                       break;
                   case 4:
                       DoPackages(reqObj);
                       strReadKey = Console.ReadKey().KeyChar.ToString();
                       int.TryParse(strReadKey, out selectionKey);
                       break;
                   case 5:
                       DoAll(reqObj);
                       strReadKey = Console.ReadKey().KeyChar.ToString();
                       int.TryParse(strReadKey, out selectionKey);
                       break;
                   case 6:
                       Environment.Exit(0);
                       break;
                   default:
                       DoAll(reqObj);
                       strReadKey = Console.ReadKey().KeyChar.ToString();
                       int.TryParse(strReadKey, out selectionKey);
                       break;
               }
           }
