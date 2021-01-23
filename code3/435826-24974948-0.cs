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
                ProfilePics pics = new ProfilePics() { filename = "04D2", fullurl = "http://demo.com/04D2", mainpic = false, status = "ok" };
                foreach (object pic in pics)
                {
                    Console.WriteLine(pic);
                    //if (pic is string) ...
                    //else if (pic is bool) ...
                }
            }
        }
    }
