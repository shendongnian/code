    namespace CustomControls
    {
        #region USING
    
        using System;
        using System.ComponentModel;
        using System.Drawing;
        using System.Windows.Forms;
    
        #endregion
    
        public class CustomTabControl : TabControl
        {
            #region VARIABLES
    
            private int hotTrackTab = -1;
    
            #endregion
    
            #region INSTANCE CONSTRUCTORS
    
            public CustomTabControl() : base()
            {
                this.InitializeComponent();
            }
    
            #endregion
    
            #region INSTANCE METHODS
    
            private void InitializeComponent()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    
                this.DrawMode = TabDrawMode.OwnerDrawFixed;
            }
    
            private int GetTabUnderCursor()
            {
                Point cursor = this.PointToClient(Cursor.Position);
                for (int index = 0; index < this.TabPages.Count; index++)
                {
                    if (this.GetTabRect(index).Contains(cursor))
                    {
                        return index;
                    }
                }
                return -1;
            }
    
            private void UpdateHotTrack()
            {
                int hot = GetTabUnderCursor();
                if (hot != this.hotTrackTab)
                {
                    if (this.hotTrackTab != -1)
                    {
                        this.Invalidate(this.GetTabRect(this.hotTrackTab));
                    }
                    this.hotTrackTab = hot;
                    if (this.hotTrackTab != -1)
                    {
                        this.Invalidate(this.GetTabRect(this.hotTrackTab));
                    }
                    this.Update();
                }
            }
    
            #endregion
    
            #region OVERRIDE METHODS
    
            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                this.UpdateHotTrack();
            }
    
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                this.UpdateHotTrack();
            }
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                this.UpdateHotTrack();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                switch (this.Alignment)
                {
                    case TabAlignment.Bottom:
                    case TabAlignment.Left:
                    case TabAlignment.Right:
                    case TabAlignment.Top:
                    default:
                        throw new NotImplementedException();
                }
            }
    
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                base.OnPaintBackground(pevent);
            }
    
            #endregion
        }
    }
