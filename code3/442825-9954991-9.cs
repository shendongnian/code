       class mydict
       {
           public static List<Dictionary<string, Bitmap>> loadAllDicts()
           {
               List<Dictionary<string, Bitmap>> lookups = new List<Dictionary<string, Bitmap>>();
                Dictionary<string, Bitmap> lookup1 = new Dictionary<string, Bitmap>();
                Bitmap l1 = new Bitmap(@"C:\1\1.bmp", true); 
                lookup1.Add("1", l1);
                lookups.Add(lookup1);
                Dictionary<string, Bitmap> lookup2 = new Dictionary<string, Bitmap>();
                Bitmap l2 = new Bitmap(@"C:\1\1.bmp", true); 
                lookup2.Add("1", l2);
                lookups.Add(lookup2);
                //etc
                return lookups;
            }
        }
