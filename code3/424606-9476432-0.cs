    I think it should get you all the child nodes from your root node 
  
     XmlDocument doc = new XmlDocument();
            doc.LoadXml("nameofyourfile.xml");
        
            XmlNode root = doc.FirstChild;
        
            //Display the contents of the child nodes.
            if (root.HasChildNodes)
            {
              for (int i=0; i<root.ChildNodes.Count; i++)
              {
                 if(root.ChildNodes[i].InnerText!="")
                 {
                Console.WriteLine(root.ChildNodes[i].InnerText);
                    }
              }
            }
          }
        }
