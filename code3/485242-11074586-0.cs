         abstract class CustomTreeDataNode : TreeNode
         {
            public CustomTreeDataNode()
            {
            }   
            protected void ReadChildNodes<T>(XmlNode parent, string childNodeName)  
                 where T: CustomTreeDataNode, new()
           {
                  foreach(XmlNode node in parent.Select(childNodeName))
                  {
                      T item = new T();
                      item.Fill(node);
                      Nodes.Add(item);
                  }
           }
            public void Fill(XmlNode node)
            {
                 Nodes.Clear();
                 InitProperties(node);
            }
           
            protected abstract void InitProperties(XmlNode node);
         }
         
         class RootNode : CustomTreeDataNode
         {
            protected override void InitProperties(XmlNode source)
            {
                Text = "Root";
                ItemIndex = ROOT_ITEMINDEX;
                SelectedIndex = ROOT_SELECTEDINDEX;
                ReadChildNodes<FileNode>(source, "Files"));
            }
         }
         class FileNode : CustomTreeDataNode
         {
            protected override void InitProperties(XmlNode source)
            {
                Text = source["name"];
                ItemIndex = FILE_ITEMINDEX;
                SelectedIndex = FILE_SELECTEDINDEX;
                ReadChildNodes<SectionNode>(source, "Section"));
            }
         }  
         
         class SectionNode : CustomTreeDataNode
         {
            protected override void InitProperties(XmlNode source)
            {
                Text = source["name"];
                ItemIndex = SECTION_ITEMINDEX;
                SelectedIndex = SECTION_SELECTEDINDEX;
                ReadChildNodes<DataNode>(source, "Data"));
            }
         }  
         class DataNode : CustomTreeDataNode
         {
            protected override void InitProperties(XmlNode source)
            {
                Text = source.Text;
                ItemIndex = DATA_ITEMINDEX;
                SelectedIndex = DATA_SELECTEDINDEX;
            }
         }  
         ...
         RootNode root = new RootNode();
         root.Fill(rootXmlNode); 
         trewView1.Nodes.Add(root);
