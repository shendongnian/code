        /// <summary>
        /// Initalizes Tree View
        /// </summary>
        private void InitializeTreeView()
        {
            var mappingList = ReadXmlData();
            BuildTree(mappingList);
        }
        /// <summary>
        /// Reads Mappings from xml file to a List
        /// </summary>
        /// <returns></returns>
        private List<Mapping> ReadXmlData()
        {
            var mappingList = new List<Mapping>();
            var reader = new XmlTextReader(@"D:\data.xml");
            while (reader.Read())
            {
                reader.ReadToFollowing("system");
                string system = reader.ReadString();
                reader.ReadToFollowing("subsystem");
                string subSystem = reader.ReadString();
                reader.ReadToFollowing("subsubsystem");
                string subSubSystem = reader.ReadString();
                mappingList.Add(new Mapping() { _system = system, _subSystem = subSystem, _subSubSystem = subSubSystem });
            }
            return mappingList;
        }
        /// <summary>
        /// Builds Tree
        /// </summary>
        /// <param name="mappingList"></param>
        private void BuildTree(List<Mapping> mappingList)
        {
            foreach (var mapping in mappingList)
            {
                var systemNode = FindNode(mapping._system, NodeType.System);
                if (string.IsNullOrEmpty(systemNode.Text))
                {
                    string nodeText = NodeType.System.ToString() + " - " + mapping._system; ;
                    systemNode.Text = nodeText;
                    systemNode.Name = nodeText;
                    treeView1.Nodes.Add(systemNode);
                }
                var subSystemNode = FindNode(mapping._subSystem, NodeType.SubSystem);
                if (string.IsNullOrEmpty(subSystemNode.Text))
                {
                    string nodeText = NodeType.SubSystem.ToString() + " - " + mapping._subSystem;
                    subSystemNode.Text = nodeText;
                    subSystemNode.Name = nodeText;
                    systemNode.Nodes.Add(subSystemNode);
                }
                var subSubSystemNode = FindNode(mapping._subSubSystem, NodeType.SubSubSystem);
                if (string.IsNullOrEmpty(subSubSystemNode.Text))
                {
                    string nodeText = NodeType.SubSubSystem.ToString() + " - " + mapping._subSubSystem;
                    subSubSystemNode.Text = nodeText;
                    subSubSystemNode.Name = nodeText;
                    subSystemNode.Nodes.Add(subSubSystemNode);
                }
            }
        }
        /// <summary>
        /// Returns an existing node from the treeview other-wise returns a new node
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private TreeNode FindNode(string data, NodeType type)
        {
            string text = type.ToString() + " - " + data;
            if (treeView1.Nodes.Find(text, true).FirstOrDefault() != null)
            {
                return treeView1.Nodes.Find(text, true).FirstOrDefault();
            }
            else
            {
                return new TreeNode();
            }
        }
        /// <summary>
        /// Class for Mapping
        /// </summary>
        public class Mapping
        {
            public string _system;
            public string _subSystem;
            public string _subSubSystem;
        }
        /// <summary>
        /// Type of Node
        /// </summary>
        public enum NodeType
        {
            System = 0,
            SubSystem = 1,
            SubSubSystem = 2
        }
