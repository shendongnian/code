    foreach (XmlNode categoryNode in itemNode.SelectNodes("category"))
    {
       //CMS.SiteProvider.CategoryInfo GetCate = null;
       
       //string CategoryName = itemNode.SelectSingleNode("category").InnerText; // incorrect
       string CategoryName = categoryNode.InnerText;
       Console.Write(CategoryName);
    }
