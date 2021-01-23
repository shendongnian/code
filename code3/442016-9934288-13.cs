    using System;
    using System.Windows.Forms;
    using System.IO;
    public class TreeBuilder
    {
        public TreeBuilder()
        {
            TreeNode rootNode = new TreeNode(@"\");
            rootNode.Name = @"\";
            RootNode = rootNode;
        }
        public TreeNode RootNode
        {
            get;
            set;
        }
        public void AddItems(string[] items)
        {
            Array.Sort(items);
            if (string.IsNullOrEmpty(RootNode.Name))
            {
                RootNode.Name = @"\";
            }
            foreach (string item in items)
            {
                string[] itemParts = item.Split(new string[] { "@@" }, StringSplitOptions.None);
                string filePath = itemParts[0].TrimEnd('\\');
                string versionPath = itemParts[1];
                TreeNode fileNode = AddNode(RootNode, filePath);
                TreeNode versionNode = AddNode(fileNode, filePath + "@@", versionPath);
            }
        }
        public TreeNode AddNode(TreeNode topNode, string path)
        {
            return AddNode(topNode, null, path);
        }
        public TreeNode AddNode(TreeNode topNode, string pathPrefix, string path)
        {
            pathPrefix = pathPrefix ?? string.Empty;
            TreeNode node = null;
            if (!string.IsNullOrEmpty(path) && topNode.Name != path)
            {
                string parentPath = Path.GetDirectoryName(path);
                TreeNode[] matchingNodes = topNode.Nodes.Find(pathPrefix + path, true);
                if (matchingNodes == null || matchingNodes.Length == 0)
                {
                    string nodeLabel = Path.GetFileName(path);
                    nodeLabel = string.IsNullOrEmpty(nodeLabel) ? @"\" : nodeLabel;
                    node = new TreeNode(nodeLabel);
                    node.Name = pathPrefix + path;
                    TreeNode[] parentNodes = topNode.Nodes.Find(pathPrefix + parentPath, true);
                    TreeNode parentNode = null;
                    if (parentNodes != null && parentNodes.Length > 0)
                    {
                        parentNode = parentNodes[0];
                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        parentNode = AddNode(topNode, pathPrefix, parentPath);
                        parentNode.Nodes.Add(node);
                    }
                }
                else
                {
                    node = matchingNodes[0];
                }
            }
            else
            {
                node = topNode;
            }
            return node;
        }
    }
