                Console.WriteLine("INSERTION SORT ON APP SIZE DEPLOYED!");
            Apps Temp, PrTemp;
            int II;
            for (int IO = 1; IO <= (Count(DeployedApps) - 1); IO++)
            {
                Temp = (Apps)DeployedApps[IO];
                PrTemp = (Apps)DeployedApps[IO - 1];
                II = IO;
                while ((II>0)&&(Temp.GetSize()>=PrTemp.GetSize()))
                {
                    SwapDEP(II, II - 1);
                    II = II - 1;
                    if (II >= 1)
                    {
                        Temp = (Apps)DeployedApps[II];
                        PrTemp = (Apps)DeployedApps[II - 1];
                    }
                }
            }
            Console.WriteLine("DONE!");
