    using System;
    using MediaInfoLib;
    
    
    namespace ConsoleApplication1
    {
        
        class Program
        {
      
            private static void Main(string[] args)
            {
    
                MediaInfo info = new MediaInfo();
                info.Open(@"E:\Songs Collection\Video's\Hindi Song's\Ajab.Si.By.HFZ.avi");
                var movie_lenstr = info.Get(StreamKind.General, 0, "Duration");
                Int32 movie_len;
                if (Int32.TryParse(movie_lenstr, out movie_len))
                {
                    Console.WriteLine("Length of movie in milli-second : {0}", movie_len);
                }
                info.Close();
    
            }
    
        }
    
    }
