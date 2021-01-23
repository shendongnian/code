    string srxPathOfCategory = "//ul[@class='ui-posts-list']//li";
            
            foreach (var att in doc.DocumentNode.SelectNodes(srxPathOfCategory))
            {
                
                foreach (var child in att.ChildNodes.Skip(3)) // skipping first three nodes //- first one is whitespace - marked as #text child node, then there is h5 and third is //another whitespace marked as #text child node 
                {
                    
                    if (child.InnerText == "odpad!")
                    {
                        b[j] = child.InnerText;
                        Console.WriteLine(b[j]);
                        Console.ReadKey();
                        break;
                    }
                    else if (child.Attributes["alt"] != null)
                    {
                        b[j] = child.Attributes["alt"].Value;
                        Console.WriteLine(b[j]);
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        b[j] = "without user evaluation";
                        Console.WriteLine("hlupost");
                        Console.ReadKey();
                        break;
                    }
                }
                j++;
            }
