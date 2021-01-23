    using System;
    using System.IO;
    using System.Windows.Forms;
    using TreeViewTestProject.Utilities;
    using System.Collections;
    namespace TreeViewTestProject
    {
        public partial class ExplorerTreeView : TreeViewEx
        {
                                                                                                        #region ExplorerNodeSorter Class
        private class ExplorerNodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode nx = x as TreeNode;
                TreeNode ny = y as TreeNode;
                bool nxDir = (nx.ImageKey == kDirectoryImageKey);
                bool nyDir = (ny.ImageKey == kDirectoryImageKey);
                if(nxDir && !nyDir)
                {
                    return -1;
                }
                else if(nyDir && !nxDir)
                {
                    return 1;
                }
                else
                {
                    return string.Compare(nx.Text, ny.Text);
                }
            }
        }
        #endregion
            private const string kDirectoryImageKey = "directory";
            private const string kReplacementText   = "C43C65D1-D40F-46F0-BC5E-57265322DDFC";
            public ExplorerTreeView()
            {
                InitializeComponent();
                this.BeforeExpand       += new TreeViewCancelEventHandler(ExplorerTreeView_BeforeExpand);
                this.ImageList          = m_FileIcons;
                this.TreeViewNodeSorter = new ExplorerNodeSorter();
                this.LabelEdit          = true;
                // Create the root of the tree and populate it
                PopulateTreeView(@"C:\");
            }
            private void PopulateTreeView(string DirectoryName)
            {
                this.BeginUpdate();
                string rootDir      = DirectoryName;
                TreeNode rootNode   = CreateTreeNode(rootDir);
                rootNode.Text       = rootDir;
                this.Nodes.Add(rootNode);
                PopulateDirectory(rootNode);
                this.EndUpdate();
            }
            private bool PathIsDirectory(string FullPath)
            {
                FileAttributes attr = File.GetAttributes(FullPath);
                return ((attr & FileAttributes.Directory) == FileAttributes.Directory);
            }
            private TreeNode CreateTreeNode(string FullPath)
            {
                string key  = FullPath.ToLower();
                string name = "";
                object tag  = null;
                if(PathIsDirectory(key))
                {
                    DirectoryInfo info = new DirectoryInfo(FullPath);
                    key     = kDirectoryImageKey;
                    name    = info.Name;
                    tag     = info;
                }
                else
                {
                    FileInfo info = new FileInfo(FullPath);
                    name    = info.Name;
                    tag     = info;
                }
                if(!m_FileIcons.Images.ContainsKey(key))
                {
                    if(key == "directory")
                    {
                        m_FileIcons.Images.Add(key, IconReader.GetFolderIcon(Environment.CurrentDirectory, IconReader.IconSize.Small, IconReader.FolderType.Open).ToBitmap());
                    }
                    else
                    {
                        m_FileIcons.Images.Add(key, IconReader.GetFileIcon(FullPath, IconReader.IconSize.Small, false));
                    }
                }
                TreeNode node           = new TreeNode(name);            
                node.Tag                = tag;
                node.ImageKey           = key;
                node.SelectedImageKey   = key;
                return node;
            }
            private void PopulateDirectory(TreeNode ParentNode)
            {
                DirectoryInfo parentInfo = ParentNode.Tag as DirectoryInfo;
                foreach(DirectoryInfo subDir in parentInfo.GetDirectories())
                {
                    TreeNode child = CreateTreeNode(subDir.FullName);
                    PopulateForExpansion(child);
                    ParentNode.Nodes.Add(child);
                }
                foreach(FileInfo file in parentInfo.GetFiles())
                {
                    ParentNode.Nodes.Add(CreateTreeNode(file.FullName));
                }
            }
            private void PopulateForExpansion(TreeNode ParentNode)
            {
                // We need the +/- to show up if this directory isn't empty... but only want to populate the node on demand
                DirectoryInfo parentInfo = ParentNode.Tag as DirectoryInfo;
                try
                {
                    if((parentInfo.GetDirectories().Length > 0) || (parentInfo.GetFiles().Length > 0))
                    {
                        ParentNode.Nodes.Add(kReplacementText);
                    }
                }
                catch { }
            }
            private void ReplacePlaceholderDirectoryNode(TreeNode ParentNode)
            {
                if((ParentNode.Nodes.Count == 1) && (ParentNode.Nodes[0].Text == kReplacementText))
                {
                    ParentNode.Nodes.Clear();
                    PopulateDirectory(ParentNode);
                }
            }
            private void ExplorerTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
            {
                this.BeginUpdate();
                ReplacePlaceholderDirectoryNode(e.Node);
                this.EndUpdate();
            }
        }
    }
