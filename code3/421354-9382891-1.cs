    public static string createProduct(string pName, decimal pPrice)
    {string postData = @"<?xml version=""1.0"" encoding=""UTF-8""?
                         <product>
                             <name>" + pName + @"</name>
                             <price>" + pPrice+ @"</price>
                         </product>";
    ....some other codes...}
