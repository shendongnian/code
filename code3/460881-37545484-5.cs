        namespace Bravo.Bravo7.UI
        {
            public class MyPropertyGrid : PropertyGrid
            {
                public class SnappableControl : NativeWindow
                {
                    private Control _parent;
                    private MyPropertyGrid _ownerGrid;
                    public SnappableControl(Control parent, MyPropertyGrid ownerGrid)
                    {
                        _parent = parent;
                        _parent.HandleCreated += _parent_HandleCreated;
                        _parent.HandleDestroyed += _owner_HandleDestroyed;
                        _ownerGrid = ownerGrid;
                    }
                    protected override void WndProc(ref Message m)
                    {
                        base.WndProc(ref m);
                        switch (m.Msg)
                        {
                            case (int)NativeMethods.WM_NCPAINT:
                            case (int)NativeMethods.WM_PAINT:
                                using (var g = _parent.CreateGraphics())
                                {
                                    using (var pen = new Pen(_ownerGrid.HelpBackColor))
                                    {
                                        var clientRectangle = _parent.ClientRectangle;
                                        clientRectangle.Width--;
                                        clientRectangle.Height--;
                                        g.DrawRectangle(pen, clientRectangle);
                                    }
                                }
                                break;
                        }
                    }
                    void _owner_HandleDestroyed(object sender, EventArgs e)
                    {
                        ReleaseHandle();
                    }
                    void _parent_HandleCreated(object sender, EventArgs e)
                    {
                        AssignHandle(_parent.Handle);
                    }
                }
                public class PropertyGridView : NativeWindow
                {
                    private Control _parent;
                    private MyPropertyGrid _ownerGrid;
                    public PropertyGridView(Control parent, MyPropertyGrid ownerGrid)
                    {
                        _parent = parent;
                        _parent.HandleCreated += _owner_HandleCreated;
                        _parent.HandleDestroyed += _owner_HandleDestroyed;
                        _ownerGrid = ownerGrid;
                    }
                    protected override void WndProc(ref Message m)
                    {
                        base.WndProc(ref m);
                        switch (m.Msg)
                        {
                            case (int)NativeMethods.WM_NCPAINT:
                            case (int)NativeMethods.WM_PAINT:
                                using (var g = _parent.CreateGraphics())
                                {
                                    using (var pen = new Pen(_ownerGrid.LineColor))
                                    {
                                        g.DrawRectangle(pen, 0, 0, _parent.Width - 1, _parent.Height - 1);
                                    }
                                }
                                break;
                        }
                    }
                    void _owner_HandleDestroyed(object sender, EventArgs e)
                    {
                        ReleaseHandle();
                    }
                    void _owner_HandleCreated(object sender, EventArgs e)
                    {
                        AssignHandle(_parent.Handle);
                    }
                }
                public class MyToolStripRenderer : ToolStripSystemRenderer
                {
                    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
                    {
                        //base.OnRenderToolStripBorder(e);
                    }
                }
                public MyPropertyGrid()
                {
                    base.LineColor = SystemColors.Control;
                    base.ViewBackColor = Color.FromArgb(246, 246, 246);
                    base.DrawFlatToolbar = true;
                    base.ToolStripRenderer = new MyToolStripRenderer();
                    var docDocument = typeof(PropertyGrid)
                        .GetField("doccomment", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(this) as Control;
                    new SnappableControl(docDocument, this);
                    var gridView = typeof(PropertyGrid)
                        .GetField("gridView", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(this) as Control;
                    new PropertyGridView(gridView, this);
                }
            }
        }
