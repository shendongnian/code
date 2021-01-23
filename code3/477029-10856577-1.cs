        public void ToListViewItem(ListViewItem listViewItem)
        {
            listViewItem.Text = SnmpV3Username;
            listViewItem.SubItems[0].Text = SecurityMode.ToString();
            listViewItem.SubItems[1].Text = AuthenticationProtocol.ToString();
            listViewItem.SubItems[2].Text = PrivacyProtocol.ToString();
            listViewItem.Tag = this;
        }
