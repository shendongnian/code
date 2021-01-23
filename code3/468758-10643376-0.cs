     var pagesWithControl = from page in sitefinityPageDictionary
                       from control in cmsManager.GetPage(page.Value).Controls
                       where control.TypeName == controlType
                       select new 
                               { 
                                 Key = page.Key.Replace("~",localhost"), 
                                 page.Value 
                               };
