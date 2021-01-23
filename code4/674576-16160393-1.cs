        public void Repopulate()
        {
            BrowserInstance currentSelectedItem = m_SelectedItem;
            Populate();
            if (m_Items.Count>0)
            {
                if (currentSelectedItem !=null && m_Items.FirstOrDefault((bi) => bi.Process == currentSelectedItem .Process) != null)
                {
                    SelectedItem = currentSelectedItem;
                }
                else
                {
                    SelectedItem = m_Items[0];
                }
            }
        }
