     private void GetImagesInHTMLString(string htmlString)
        {
          
            List<string> images = new List<string>();
            string pattern = @"<(img)\b[^>]*>";
    
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);
             string b =@"src=""";
             string c=@"src="""+myurl+"";
    
             //if (matches.Count >1)
             //{
                for (int i = 0, l =matches.Count; i < l; i++)
                 {
                
                   
                     string pattern1 =@"s/\s*src='[^']*'//";
                     //    images.Add(matches[i].Value.Replace(b, c));
                     string allmatch = matches[i].Value.Replace(b, c);
                    string patrern1="#(= src=['\"].+[^\"]?)?src=[\"']?([^\"']+)#i";  
                     Regex rgx1 = new Regex(pattern1);
                     MatchCollection matches1 = rgx1.Matches(allmatch);
                     string siya = matches1[0].Value.ToString();
                     //string b = @"src=""";
                     //string c = @"src=""" + myurl + "";
                 }
            // }       
            
            foreach (var item in images)
            {
                Response.Write(item);
            }        
        }
