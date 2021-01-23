    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace TreeViewTestProject
    {
        public partial class TreeViewEx : TreeView
        {
            // Notes: TextRenderer uses GDI to render the text, whereas Graphics uses GDI+.  "TreeView" has existed for a long long time
            // and thus uses GDI under the covers.  For User Drawing TreeNode's, we need to make sure we use the TextRenderer version
            // of text rendering functions.
            #region Properties
            private DashStyle m_SelectionDashStyle = DashStyle.Dot;
            public DashStyle SelectionDashStyle
            {
                get { return m_SelectionDashStyle; }
                set { m_SelectionDashStyle = value; }
            }
            private DashStyle m_LineStyle = DashStyle.Solid;
            public DashStyle LineStyle
            {
                get { return m_LineStyle; }
                set { m_LineStyle = value; }
            }
            private bool m_ShowLines = true;
            public new bool ShowLines           // marked as 'new' to replace base functionality fixing ShowLines/FullRowSelect issues in base.
            {
                get { return m_ShowLines; }
                set { m_ShowLines = value; }
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    // Removes all the flickering of repainting node's
                    // This is the only thing I found that works properly for doublebuffering a treeview.
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000; // WS_CLIPCHILDREN
                    return cp;
                }
            }
            #endregion
            [DllImport("user32.dll", ExactSpelling = false, CharSet = CharSet.Auto)]
            private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, HandleRef lParam);
            private const int GWL_STYLE         = -16;
            private const int WS_VSCROLL        = 0x00200000;
            private const uint TV_FIRST         = 0x1100;
            private const uint TVM_EDITLABELA   = (TV_FIRST + 14);
            private const uint TVM_EDITLABELW   = (TV_FIRST + 65);
            private bool m_SelectionChanged = false;
            private bool m_DoubleClicked    = false;
            private bool m_HierarchyChanged = false;
            public TreeViewEx()
            {
                InitializeComponent();
                // ShowLines must be "false" for FullRowSelect to work - so we're overriding the variable to correct for that.
                base.ShowLines = false;
                this.FullRowSelect = true;
                this.ItemHeight = 21;
                this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
                this.DrawNode += OnDrawNode;
            }
            private void OnDrawNode(object sender, DrawTreeNodeEventArgs e)
            {
                e.DrawDefault = false;
                if(e.Node.Bounds.IsEmpty) return;
                // Clear out the previous contents for the node.  If we don't do this, when you mousehover the font will get slightly more bold
                Rectangle bounds = new Rectangle(0, e.Node.Bounds.Y, this.Width - 1, e.Node.Bounds.Height - 1);
                e.Graphics.FillRectangle(SystemBrushes.Window, bounds);
                // Draw everything
                DrawNodeFocusedHighlight(e);
                DrawNodeLines(e);
                DrawPlusMinus(e);
                DrawNodeIcon(e);
                DrawNodeText(e);
            }
            private void DrawNodeFocusedHighlight(DrawTreeNodeEventArgs e)
            {
                if(SelectedNode != e.Node) return;
                int scrollWidth = 0;
                if(VScrollVisible())
                {
                    scrollWidth = SystemInformation.VerticalScrollBarWidth;
                }
                Rectangle bounds = new Rectangle(0, e.Node.Bounds.Y, this.Width - scrollWidth, e.Node.Bounds.Height - 1);
                if(!e.Node.IsEditing)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);
                }
                using(Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = SelectionDashStyle;
                    bounds = new Rectangle(0, e.Node.Bounds.Y, this.Width - scrollWidth - 5, e.Node.Bounds.Height - 2);
                    e.Graphics.DrawRectangle(focusPen, bounds);
                }
            }
            private void DrawNodeText(DrawTreeNodeEventArgs e)
            {
                if(e.Node.Bounds.IsEmpty) return;
                if(e.Node.IsEditing) return;
                Rectangle bounds = e.Node.Bounds;
                using(Font font = e.Node.NodeFont)
                {
                    bounds.Width = TextRenderer.MeasureText(e.Node.Text, font).Width;
                    bounds.Y -= 1;
                    bounds.X += 1;
                    if(IsRootNode(e.Node))
                    {
                        bounds = new Rectangle(this.Margin.Size.Width + Properties.Resources.minus.Width + 9, 0, bounds.Width, bounds.Height);
                    }
                    Color fontColor = SystemColors.InactiveCaptionText;
                    if(this.Focused)
                    {
                        fontColor = e.Node.IsSelected?SystemColors.HighlightText:this.ForeColor;
                    }
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, bounds, fontColor);
                }
            }
            private bool IsRootNode(TreeNode Node)
            {
                return (Node.Level == 0 && Node.PrevNode == null);
            }
            private void DrawNodeLines(DrawTreeNodeEventArgs e)
            {
                DrawNodeLineVertical(e);
                DrawNodeLineHorizontal(e);
            }
            private void DrawNodeLineVertical(DrawTreeNodeEventArgs e)
            {
                if(IsRootNode(e.Node)) return;
                if(!ShowLines) return;
                Pen linePen       = new Pen(Color.Black);
                linePen.DashStyle = LineStyle;
                for(int x = 0; x < e.Node.Level; x++)
                {
                    int xLoc = this.Indent + (x * this.Indent) + (Properties.Resources.minus.Width / 2);
                    int height = e.Bounds.Height;
                    if(ShouldDrawVerticalLineForLevel(e.Node, x))
                    {
                        e.Graphics.DrawLine(linePen, xLoc, e.Bounds.Top, xLoc, e.Bounds.Top + height);
                    }
                }
                // Draw the half line for the last node
                if(e.Node.Parent.LastNode == e.Node)
                {
                    int halfLoc = (e.Node.Level * this.Indent) + (Properties.Resources.minus.Width / 2);
                    e.Graphics.DrawLine(linePen, halfLoc, e.Bounds.Top, halfLoc, (e.Bounds.Top + e.Bounds.Height / 2) - 1);
                }
            }
            private bool ShouldDrawVerticalLineForLevel(TreeNode Current, int Level)
            {
                TreeNode node = Current;
                TreeNode c = Current;
                while(node.Level != Level)
                {
                    c = node;
                    node = node.Parent;
                }
                return !(node.LastNode == c);
            }
            private void DrawNodeLineHorizontal(DrawTreeNodeEventArgs e)
            {
                if(IsRootNode(e.Node)) return;
                if(!ShowLines) return;
                Pen linePen         = new Pen(Color.Black);
                int xLoc            = (e.Node.Level * this.Indent) + (Properties.Resources.minus.Width / 2);
                int midY            = (e.Bounds.Top + e.Bounds.Bottom) / 2 - 1;
                e.Graphics.DrawLine(linePen, xLoc, midY, xLoc + 7, midY);
            }
            private void DrawNodeIcon(DrawTreeNodeEventArgs e)
            {
                if(this.ImageList == null) return;
                int indent = (e.Node.Level * this.Indent) + this.Margin.Size.Width;
                int iconLeft = indent + this.Indent;
                int imgIndex = this.ImageList.Images.IndexOfKey(e.Node.ImageKey);
                if(!IsRootNode(e.Node))
                {
                    if(imgIndex >= 0)
                    {
                        Image img = this.ImageList.Images[imgIndex];
                        int y = (e.Bounds.Y + e.Bounds.Height / 2) - (img.Height / 2) - 1;
                        e.Graphics.DrawImage(img, new Rectangle(iconLeft, y, img.Width, img.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                    }
                }
            }
            private void DrawPlusMinus(DrawTreeNodeEventArgs e)
            {
                if(e.Node.Nodes.Count == 0) return;
                int indent = (e.Node.Level * this.Indent) + this.Margin.Size.Width;
                int iconLeft = indent + this.Indent;
                Image img = Properties.Resources.plus;
                if(e.Node.IsExpanded) img = Properties.Resources.minus;
                e.Graphics.DrawImage(img, iconLeft - img.Width - 2, (e.Bounds.Y + e.Bounds.Height / 2) - (img.Height / 2) - 1);
            }
            private bool VScrollVisible()
            {
                int style = GetWindowLong(this.Handle, GWL_STYLE);
                return ((style & WS_VSCROLL) != 0);
            }
            private void BeginEditNode()
            {
                if(this.SelectedNode == null) return;
                if(!this.LabelEdit) throw new Exception("This TreeView is not configured with LabelEdit=true");
                IntPtr result = SendMessage(new HandleRef(this, this.Handle), TVM_EDITLABELA, IntPtr.Zero, new HandleRef(this.SelectedNode, this.SelectedNode.Handle));
                if(result == IntPtr.Zero)
                {
                    throw new Exception("Failed to send EDITLABEL message to TreeView control.");
                }
            }
            private void TreeViewEx_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
            {
                if(m_DoubleClicked)
                {
                    m_DoubleClicked = false;
                    return;
                }
                if(m_SelectionChanged)
                {
                    e.CancelEdit = true;
                    m_SelectionChanged = false;
                }
            }
            private void TreeViewEx_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                if(m_HierarchyChanged)
                {
                    m_HierarchyChanged = false;
                    return;
                }
                if((e.Button & MouseButtons.Left) > 0)
                {
                    if(this.LabelEdit && (this.SelectedNode != null))
                    {
                        m_DoubleClicked = true;
                        BeginInvoke(new MethodInvoker(delegate() { this.SelectedNode.BeginEdit(); }));
                    }
                }
            }
            private void TreeViewEx_AfterCollapse(object sender, TreeViewEventArgs e)
            {
                m_HierarchyChanged = true;
            }
            private void TreeViewEx_AfterExpand(object sender, TreeViewEventArgs e)
            {
                m_HierarchyChanged = true;
            }
        }
    }
