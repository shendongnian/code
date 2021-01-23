    /// <summary>
    /// PopupHelper
    /// </summary>
    public sealed class PopupHelper : IDisposable
    {
        private readonly Control m_control;
        private readonly ToolStripDropDown m_tsdd;
        private readonly Panel m_hostPanel; // workarround - some controls don't display correctly if they are hosted directly in ToolStripControlHost
        public PopupForm(Control pControl)
        {
            m_hostPanel = new Panel();
            m_hostPanel.Padding = Padding.Empty;
            m_hostPanel.Margin = Padding.Empty;
            m_hostPanel.TabStop = false;
            m_hostPanel.BorderStyle = BorderStyle.None;
            m_hostPanel.BackColor = Color.Transparent;
            m_tsdd = new ToolStripDropDown();
            m_tsdd.CausesValidation = false;
            
            m_tsdd.Padding = Padding.Empty;
            m_tsdd.Margin = Padding.Empty;
            m_tsdd.Opacity = 0.9;
            m_control = pControl;
            m_control.CausesValidation = false;
            m_control.Resize += MControlResize;
            
            m_hostPanel.Controls.Add(m_control);
            
            m_tsdd.Padding = Padding.Empty;
            m_tsdd.Margin = Padding.Empty;
            m_tsdd.MinimumSize = m_tsdd.MaximumSize = m_tsdd.Size = pControl.Size;
            m_tsdd.Items.Add(new ToolStripControlHost(m_hostPanel));
        }
        private void ResizeWindow()
        {
            m_tsdd.MinimumSize = m_tsdd.MaximumSize = m_tsdd.Size = m_control.Size;
            m_hostPanel.MinimumSize = m_hostPanel.MaximumSize = m_hostPanel.Size = m_control.Size;
        }
        private void MControlResize(object sender, EventArgs e)
        {
            ResizeWindow();
        }
        /// <summary>
        /// Display the popup and keep the focus
        /// </summary>
        /// <param name="pParentControl"></param>
        public void Show(Control pParentControl)
        {
            if (pParentControl == null) return;
            // position the popup window
            var loc = pParentControl.PointToScreen(new Point(0, pParentControl.Height));
            m_tsdd.Show(loc);
            m_control.Focus();
        }
        public void Close()
        {
            m_tsdd.Close();
        }
        public void Dispose()
        {
            m_control.Resize -= MControlResize;
            m_tsdd.Dispose();
            m_hostPanel.Dispose();
        }
    }
