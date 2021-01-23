      Regex imgRule = new Regex("img id=\\\".+?\\\"");
                            MatchCollection matches = imgRule.Matches(content.Value);
                            string result = null;
                            foreach (Match match in matches) {
                                result = match.Value;
                            
                               if (result != null)
                               {
                                   var firstOrDefault = node.ListImages.FirstOrDefault();
                                   if (firstOrDefault != null)
                                   {
                                       var htmlWithImages = content.Value.Replace(result,    string.Format("img src='{0}' class='newsimage' width='300'", firstOrDefault.ImageUrlId));
                                       node.Content = htmlWithImages;
                                   }
                               }   
                            }
