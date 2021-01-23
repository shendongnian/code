                XDocument doc = XDocument.Load(@"..\..\doc.xml");
            var AnswersScript = doc.Document.Element("root").Elements();
            
            int count = 0;
          
            foreach (var node in AnswersScript)
            {
                count++;
                if (doc.Document.Element("root").Element(node.Name).Elements().Count() > 1)
                {
                Console.WriteLine(node.Name);
                }
                else
                {}
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
