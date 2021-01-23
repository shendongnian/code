    using System;
    using System.Collections.Generic;
    
    namespace EnumerableClass
    {
        public class ProfilePics
        {
            public string status { get; set; }
            public string filename { get; set; }
            public bool mainpic { get; set; }
            public string fullurl { get; set; }
    
            public IEnumerator<object> GetEnumerator()
            {
                yield return status;
                yield return filename;
                yield return mainpic;
                yield return fullurl;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                ProfilePics pic = new ProfilePics() { filename = "04D2", fullurl = "http://demo.com/04D2", mainpic = false, status = "ok" };
                foreach (object item in pic)
                {
                    Console.WriteLine(item);
                    //if (item is string) ...
                    //else if (item is bool) ...
                }
            }
        }
    }
