    var paths = new string[] 
            {
                "C:\\WINDOWS\\addins",
                "C:\\WINDOWS\\AppPatch",
                "C:\\WINDOWS\\AppPatch\\MUI",
                "C:\\WINDOWS\\AppPatch\\MUI\\040C",
                "C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727",
                "C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727\\MUI",
                "C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727\\MUI\\0409"
            };
            const string node = "node";
            const string label = "label";
            var xml = new XElement("nodes");
            
            foreach (var path in paths)
            {
                var labelValues = path.Split('\\');
                var currentNode = xml;
                foreach (var labelValue in labelValues)
                {
                    var foundNode = currentNode.Elements(node).Where(n => (string)n.Attribute(label) == labelValue).SingleOrDefault();
                    if (foundNode != null)
                    {
                        currentNode = foundNode;
                    }
                    else
                    {
                        var newNode = new XElement(node, new XAttribute(label, labelValue));
                        currentNode.Add(newNode);
                        currentNode = newNode;
                    }
                }
            }
