                public class fastParseData
                {
                    int year;
                    int mon;
                    int day;
                    int hour;
                    int min; 
                    string previousSlice = "";
                    DateTime previousDT;
                    public DateTime fastParse(ref string s)
                    {
                        if (previousSlice != s.Substring(0, 12))
                        {
                             year=int.Parse(s.Substring(0,4));
                             mon=int.Parse(s.Substring(4,2));
                             day=int.Parse(s.Substring(6,2));
                             hour= int.Parse(s.Substring(9,2));
                             min = int.Parse(s.Substring(11,2));
                             previousSlice = s.Substring(0, 12);
                             previousDT = new DateTime(year, mon, day, hour,min,0,0);
                        }
                        return previousDT.ParseExact(year, mon, day, hour,min, int.Parse(s.Substring(13, 2)), int.Parse(s.Substring(15, 3));
                    }
                }
