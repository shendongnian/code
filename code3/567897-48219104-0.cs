    //Easy method using Linq to Count number of words in a text file
    /// www.techhowdy.com
    // Lyoid Lopes Centennial College 2018
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FP_WK13
    {
        static class Util
        {
           
            public static IEnumerable<string> GetLines(string yourtextfile)
            {
                TextReader reader = new StreamReader(yourtextfile);
                string result = string.Empty;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
                reader.Close();
            }
    
    
    
            // Word Count 
    
            public static int GetWordCount(string str)
            {         
                int words = 0;
                string s = string.Empty;
                var lines = GetLines(str);
    
                foreach (var item in lines)
                {
                    s = item.ToString();
                    words = words +  s.Split(' ').Length;
                    
                }
    
                return words;
                
            }
    
    
        }
    }
