    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace Spectrum.UI
    {
        public partial class TitleBar : UserControl
        {
            public delegate void EventHandler(object sender, EventArgs e);
            public event EventHandler MinButtonClick;
            public event EventHandler MaxButtonClick;
            public event EventHandler CloseButtonClick;
    
            #region Properties
            [Category("Appearance")]
            public string Title
            {
                get { return TitleLabel.Text; }
                set { TitleLabel.Text = value; }
            }
    
            [Category("Appearance")]
            public bool MinimizeEnabled
            {
                get
                {
                    return minButton.Visible;
                }
                set
                {
                    minButton.Visible = value;
                }
            }
    
            [Category("Appearance")]
            public bool MaximizeEnabled
            {
                get
                {
                    return maxButton.Visible;
                }
                set
                {
                    maxButton.Visible = value;
                }
            }
            #endregion
    
            public TitleBar()
            {
                InitializeComponent();
                ShowTitleBarImage = false;
            }
    
            #region Mouse Events
            private void TitleBar_MouseDown(object sender, MouseEventArgs e)
            {
                this.OnMouseDown(e);
            }
    
            private void TitleBar_MouseUp(object sender, MouseEventArgs e)
            {
                this.OnMouseUp(e);
            }
    
            private void TitleBar_MouseMove(object sender, MouseEventArgs e)
            {
                this.OnMouseMove(e);
            }
            #endregion
    
            #region Button Click Events
            private void minButton_Click(object sender, EventArgs e)
            {
                if (MinButtonClick != null)
                    this.MinButtonClick.Invoke(this, e);
            }
    
            private void maxButton_Click(object sender, EventArgs e)
            {
                if (MaxButtonClick != null) 
                    this.MaxButtonClick.Invoke(this, e);
            }
    
            private void closeButton_Click(object sender, EventArgs e)
            {
                if (CloseButtonClick != null) 
                    this.CloseButtonClick.Invoke(this, e);
            }
            #endregion
        }
    }
