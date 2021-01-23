    public class Encoded
        {
            public string Charset;
            public string ContentTransfertEncoding;
            public string Data;
        }
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Text.RegularExpressions;
        namespace ConsoleApplication2
        {
         public class Decoding
    {
     
        public Decoding()
        {
              
        }
        public List<Encoded> Process(string data)
        {
            List<Encoded> list = new List<Encoded>();
            var occurences = new Regex(@"=\?[a-zA-Z0-9?=-]*\?[BbQq]\?[a-zA-Z0-9?=-]*\?=", RegexOptions.IgnoreCase);
            var matches = occurences.Matches(data);
            foreach (Match match in matches)
            {
                Encoded cls = new Encoded();
                cls.Data = match.Groups[0].Value;
                cls.Charset = GetCharset(cls.Data);                
                cls.ContentTransfertEncoding = GetContentTransfertEncoding(cls.Data);
                
                // cleanup data
                int pos = cls.Data.IndexOf("=?");
                pos = cls.Data.IndexOf("?",pos+ 2);
                cls.Data = cls.Data.Substring(pos + 3);
                cls.Data = cls.Data.Replace("?=", "");                
                list.Add(cls);
            }
            return list;            
        }
        private string GetContentTransfertEncoding(string data)
        {
            var occurences = new Regex(@"=\?(.*?)\?[QBqb]", RegexOptions.IgnoreCase);
            var matches = occurences.Matches(data);
            foreach (Match match in matches)
            {
                int pos = match.Groups[0].Value.LastIndexOf('?');
                return match.Groups[0].Value.Substring(pos+1);
               
            }
            return data;
        }
        public string GetCharset(string data)
        {
            var occurences = new Regex(@"=\?(.*?)\?[QBqb]", RegexOptions.IgnoreCase);
            var matches = occurences.Matches(data);
            foreach (Match match in matches)
            {
                string str1 = match.Groups[0].Value.Replace("=?", "");
                int pos = str1.IndexOf('?');
                str1 = str1.Substring(0, pos);
                return str1; // there should be only 1 match
            }
            return data;
        }
        public string Decodeetc...()
       }
