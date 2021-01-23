    string ss = "pradeep rao having 2years exp";
    
                string[] SPLIT = ss.split(' ');
    
                for (int i = 0; i < SPLIT.Length; i++)
                {
                    if (SPLIT[i].Contains("years") || SPLIT[i].Contains("year"))
                    {
                        //SPLIT[i] is the required word split it or use Substring property to get the desired result
                        break;
                    }
                }
