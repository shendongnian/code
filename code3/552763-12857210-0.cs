    class Item
    {
        private string m_Order;
        private DateTime m_ExpiryDate;
        public string Order
        {
            get { return m_Order; }
            set { m_Order = value; }
        }
        public DateTime ExpiryDate
        {
            get { return m_ExpiryDate; }
            set { m_ExpiryDate = value; }
        }
    }
