    using System;
    using System.IO;
    using System.Net;
    using System.Web;
    namespace Proyecto_Prueba_04
    {
    internal class Program
    {
        public static string GetWebText(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = "A .NET Web Crawler";
            string htmlText = null;
            using (var response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            htmlText = reader.ReadToEnd();
                        }
                    }
                }
            }
            return htmlText;
        }
        public static void Main(string[] args)
        {
            const string urlPrueba = "http://президент.рф/";
            var uri = new Uri(urlPrueba);
            Console.WriteLine("urlPrueba" + " = " + uri.AbsoluteUri);
            string codigoHTML = GetWebText(uri);
            Console.WriteLine("codigoHTML" + " = " + codigoHTML);
            Console.ReadLine();
        }
    }
    } 
