    while (true)
    {
         Console.WriteLine(@"Select one of the following option:                                
                                1-Write Apps 
                                2-Write Drivers
                                3-Write OS
                                4-Write Packages
                                5-All the above
                                6-Exit");
               string strReadKey = Console.ReadKey().KeyChar.ToString();
    
               int.TryParse(strReadKey, out selectionKey);
    
    
               switch (selectionKey)
               {
    
                   case 1:
                       DoApps(reqObj);
                       break;
                   case 2:
                       DoDrivers(reqObj);
                       break;
                   case 3:
                       DoOS(reqObj);
                       break;
                   case 4:
                       DoPackages(reqObj);
                       break;
                   case 5:
                       DoAll(reqObj);
                       break;
                   case 6:
                       Environment.Exit(0);                       
                       break;
                   default:
                       DoAll(reqObj);
                       break;
               }
    }
