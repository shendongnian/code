       public static String readWebLink(  String url)
        {
         System.Net.WebClient webclient = new System.Net.WebClient();
         return  webclient.DownloadString(url);
         }
