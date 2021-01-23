        public void Test(){
        
       
            XmlDocument doc = new XmlDocument();
            string selectedTag = cmbX.text;
            if (File.Exists(txtFile.text))
            {
                try
                {
                    //Load
                    doc.Load(cmbFile.text);
                    //Select Nodes
                    XmlNodeList selectedNodeList = doc.SelectNodes(".//" + selectedTag);
                    List<XmlNode> result = new List<XmlNode>();
                    foreach(XmlNode node in selectedNodeList){
                        if(depth(node) == 2){
                            result.Add(node);
                        }
                    }
                    // result now has all the selected tags of depth 2
                }
                Catch
                {
                    MessageBox.show("Some error message here");
                } 
            }
        }
        private int depth(XmlNode node) {
            int depth = 0;
            XmlNode parent = node.ParentNode;
            while(parent != null){
                parent = node.ParentNode;
                depth++;
            }
            return depth;
        }
