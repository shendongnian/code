    public int SelectedTabIndex
        {
            get
            { return m_selectedTabIndex; }
            set
            {
                SetAndNotify(ref m_selectedTabIndex, value, () => SelectedTabIndex);
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(SelectedTabChanged), null);
            }
        }
