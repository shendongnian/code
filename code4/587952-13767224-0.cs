    class ImportRow
    {
        private string m_Status = string.Empty;
        private DateTime m_DateOrdered;
        private DateTime m_DateDue;
        public ImportRow() { }
        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        public DateTime DateOrdered
        {
            get { return m_DateOrdered; }
            set { m_DateOrdered = value; }
        }
        public DateTime DateDue
        {
            get { return m_DateDue; }
            set { m_DateDue = value; }
        }
    }
