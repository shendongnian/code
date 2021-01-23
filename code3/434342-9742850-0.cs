    public void KI_Tab_Items_ListviewControl( TabControl m_TabControl, int lIndex, bool DisplayComboBox = true )
    {
        if ( m_TabControl.TabPages[ lIndex ].Controls.Count == 0 )
        {
            int ListviewTop = 0;
            m_TabControl.TabPages[ lIndex ].Controls.Clear();
            m_TabControl.TabPages[ lIndex ].Controls.Add( ListViewControl );
            // Add ListView FIRST.
            // NOTE: set ListViewControl.Dock = DockStyle.Fill;
            //
            ListViewControl.Anchor = AnchorStyles.Top;
            ListViewControl.Dock = DockStyle.Fill;
            ListViewControl.Visible = true;
            ListViewControl.Top = ListviewTop;
            ListViewControl.Height = m_TabControl.TabPages[ lIndex ].Height - ListviewTop;
            // Add ComboBox last.
            // NOTE: set ComboBoxControl.Dock = DockStyle.Top;
            //
            if ( DisplayComboBox )
            {
                m_TabControl.TabPages[ lIndex ].Controls.Add( ComboBoxControl );
                ComboBoxControl.Dock = DockStyle.Top;
                ComboBoxControl.Visible = true;
                ComboBoxControl.Left = 0;
                ComboBoxControl.Top = 0;
                ListviewTop = ComboBoxControl.Top + ComboBoxControl.Height;
            }
        }
    }
