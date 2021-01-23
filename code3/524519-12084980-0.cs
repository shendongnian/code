        private TreeNode[] FindTreeNodes(string Key)
        {
            return oTreeView.Nodes.Find(Key, true);
        }
        private void LoadTreeview(string XmlFile)
        {
            oTreeView.Nodes.Clear();
            if (File.Exists(XmlFile) == true)
            {
                XmlDocument oXmlDocument = new XmlDocument();
                oXmlDocument.Load(XmlFile);
                XmlNodeList oXmlNodeList = oXmlDocument.SelectNodes("/Processes/Process");
                foreach (XmlNode oXmlNode in oXmlNodeList)
                {
                    int iID = Convert.ToInt32(oXmlNode.Attributes["id"].Value);
                    string sName = oXmlNode.Attributes["name"].Value;
                    int iParentID = Convert.ToInt32(oXmlNode.Attributes["ParentPID"].Value);
                    TreeNode[] oParentNodes = FindTreeNodes(iParentID.ToString());
                    if (oParentNodes.Length == 0)
                    {
                        TreeNode oTreeNode = new TreeNode();
                        oTreeNode.Name = iID.ToString();
                        oTreeNode.Text = String.Format("{0} ({1})", sName, iID);
                        oTreeView.Nodes.Add(oTreeNode);
                    }
                    else
                    {
                        if (oParentNodes.Length > 0)
                        {
                            foreach (TreeNode oParentTreeNode in oParentNodes)
                            {
                                TreeNode oTreeNode = new TreeNode();
                                oTreeNode.Name = iID.ToString();
                                oTreeNode.Text = String.Format("{0} ({1})", sName, iID);
                                oParentTreeNode.Nodes.Add(oTreeNode);
                            }
                        }
                        else
                        {
                            Console.WriteLine("  ** Could not find the parent node {0} for child {1} ({2})", iParentID, sName, iID);
                        }
                    }
                }
            }
        }
        protected override void OnLoad(EventArgs E)
        {
            base.OnLoad(E);
            LoadTreeview("Xml.xml");
        }
