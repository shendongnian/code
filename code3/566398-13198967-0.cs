    public class ClientGroupDetails
    {
        public DateTime Col2 { get; set; }
        public String Col3 { get; set; }
        public Int32 Col4 { get; set; }
        public ClientGroupDetails(DateTime m_Col2, String m_Col3, Int32 m_Col4)
        {
            Col2 = m_Col2;
            Col3 = m_Col3;
            Col4 = m_Col4;
        }
        public ClientGroupDetails() { }
    }
