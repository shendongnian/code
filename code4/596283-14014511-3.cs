    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public myContextMenuStrip myMenu;
        
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode tn = treeView1.GetNodeAt(e.Location);
                myMenu.tn = tn;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myMenu = new myContextMenuStrip();
            myMenu.Items.Add("asd");
            treeView1.ContextMenuStrip = myMenu;
        }
        public class myContextMenuStrip : ContextMenuStrip
        {
            public TreeNode tn;
            public myContextMenuStrip() { }
            protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
            {
                base.OnItemClicked(e);
                if (e.ClickedItem.Text == "asd") MessageBox.Show(tn.Text);
            }
        }
    }
    }
 
