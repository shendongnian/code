    class Program
        {
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Parse("<?xml-stylesheet type=\"text/xsl\" href=\"dco.xsl\"?><S><B></B></S>");
                doc.SaveWithoutDeclaration(Console.OpenStandardOutput());
                Console.ReadKey();
            }
    
            
        }
    
        internal static class Extensions
        {
            public static void SaveWithoutDeclaration(this XDocument doc, string FileName)
            {
                using(var fs = new StreamWriter(FileName))
                {
                    fs.Write(doc.ToString());
                }
            }
    
            public static void SaveWithoutDeclaration(this XDocument doc, Stream Stream)
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(doc.ToString());
                Stream.Write(bytes, 0, bytes.Length);
            }
        }
