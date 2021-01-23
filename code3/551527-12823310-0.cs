    class RelayType
    {
        private int m_Index;
        private string m_Value;
        public RelayType(int index, string value)
        {
            m_Index = index;
            m_Value = value;
        }
        public int Index
        {
            get { return m_Index; }
        }
        public string Value
        {
            get { return m_Value; }
        }
    }
    var relayTypeCol = new List<RelayType>(); 
    relayTypeCol.Add(new RelayType(0, ""));
    relayTypeCol.Add(new RelayType(1, "Boiler"));
    relayTypeCol.Add(new RelayType(2, "Valve"));
    relayTypeCol.Add(new RelayType(3, "Pump"));
    cmb_RelayType.DataSource = relayTypeCol; 
    cmb_RelayType.DisplayMember = "Value"; 
    cmb_RelayType.ValueMember = "Index";
