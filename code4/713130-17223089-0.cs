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
                       return;
                   case 2:
                       DoDrivers(reqObj);
                       return;
                   case 3:
                       DoOS(reqObj);
                       return;
                   case 4:
                       DoPackages(reqObj);
                       return;
                   case 5:
                       DoAll(reqObj);
                       return;
                   case 6:
                       Environment.Exit(0);                       
                       return;
                   default:
                       DoAll(reqObj);
                       return;
               }
    }
