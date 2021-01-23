    public class CustomItextImageProvider : IImageProvider
    {
        #region IImageProvider Members
        public iTextSharp.text.Image GetImage(string src, Dictionary<string,string> imageProperties, ChainedProperties cprops, IDocListener doc)
        {
            string imageLocation = imageProperties["src"].ToString();
            string siteUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");
    
            if (siteUrl.EndsWith("/"))
                siteUrl = siteUrl.Substring(0, siteUrl.LastIndexOf("/"));
    
            iTextSharp.text.Image image = null;
    
            if (!imageLocation.StartsWith("http:") && !imageLocation.StartsWith("file:") && !imageLocation.StartsWith("https:") && !imageLocation.StartsWith("ftp:"))
                imageLocation = siteUrl + (imageLocation.StartsWith("/") ? "" : "/") + imageLocation; 
    
            return iTextSharp.text.Image.GetInstance(imageLocation);
        }
        #endregion
    }
