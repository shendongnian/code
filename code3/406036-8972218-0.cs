    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ChapterSort
    {
        class Program
        {
            static void Main(string[] args)
            {
                String[] chapters=new String[] {"14.1","14.4.2","14.7.8.8.2","14.10","14.2","14.9","14.10.1.2.3.4","14.1.2.3" };  
    
    			IEnumerable<String> newchapters=chapters.OrderBy(x => new ChapterNumerizer(x,256,8).NumericValue);
    			
                foreach (String s in newchapters) Console.WriteLine(s);
    
            }
        }
    
        public class ChapterNumerizer
        {
            private long numval;
    
            public long NumericValue {get{return numval;}}
    
            public ChapterNumerizer (string chapter,int n, int m)
            {
                string[] c = chapter.Split('.');
                numval=0;
                int j=0;
    
               foreach (String cc in c)
               {
                   numval=n*numval+int.Parse(cc);
                   j++;
               }
               while (j<m)
               {
                   numval*=n;
                   j++;
               }
            }
        }
    }
