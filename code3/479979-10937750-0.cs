    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace DesktopTreeView
    {
     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
            LoadFoldersInTreeView(treeView1);
        }
        void LoadFoldersInTreeView(TreeView treeName)
        {
            treeName.BeginUpdate();
            treeName.Nodes.Add("Desktop");
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\");
            TreeNode node = new TreeNode();
            node.Text = "My Computer";
            treeName.Nodes[0].Nodes.Add(node);
        }
     }
    }
