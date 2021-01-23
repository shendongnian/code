         var sb = new StringBuilder();        
    
                using (var sw = new StringWriter(sb))
                {
                     page.Server.Execute(page, sw, false);
                }
         string emailBody = sb.ToString();
