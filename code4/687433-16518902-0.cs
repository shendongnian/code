        public void ProcessXml(string document)
        {
            var doc = XDocument.Parse(document, LoadOptions.None);
            var uniqueSystemList = doc.Element("SNS").Elements();
            var treeView = new TreeView();
            string value = string.Empty;
            string text = string.Empty;
            foreach (var uniqueSystem in uniqueSystemList)
            {
                value = uniqueSystem.Element("label").Value.ToString();
                text = uniqueSystem.Element("system").Value.ToString();
                var uniqueSystemNode = new TreeNode(text, value);
                var uniqueSubsystemList = uniqueSystem.Elements("uniqueSubsystem");
                foreach (var uniqueSubSystem in uniqueSubsystemList)
                {
                    value = uniqueSubSystem.Element("label").Value.ToString();
                    text = uniqueSubSystem.Element("subsystem").Value.ToString();
                    var uniqueSubSystemNode = new TreeNode(text, value);
                    var uniqueUnitList = uniqueSubSystem.Elements("uniqueUnit");
                    foreach (var uniqueUnit in uniqueUnitList)
                    {
                        value = uniqueUnit.Element("label").Value.ToString();
                        text = uniqueUnit.Element("unit").Value.ToString();
                        var uniqueUnitNode = new TreeNode(text, value);
                        uniqueSubSystemNode.ChildNodes.Add(uniqueUnitNode);
                    }
                    uniqueSystemNode.ChildNodes.Add(uniqueSubSystemNode);
                }
                treeView.Nodes.Add(uniqueSystemNode);
            }
        }
