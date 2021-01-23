    using System;
    using System.IO;
    using System.Net;
    using System.Web;
    namespace Proyecto_Prueba_04
    {
        class Program
        {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetWebText(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.UserAgent = "A .NET Web Crawler";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string htmlText = reader.ReadToEnd();
            return htmlText;
        } // End of the GetWebText method.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {
            string urlPrueba = "http://президент.рф/";
            Uri uri = new Uri(urlPrueba);
            Console.WriteLine("urlPrueba" + " = " + uri.AbsoluteUri);
            string codigoHTML = GetWebText(uri);
            Console.WriteLine("codigoHTML" + " = " + codigoHTML);
            Console.ReadLine();
        } 
    } 
} 
