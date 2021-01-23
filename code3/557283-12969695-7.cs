        public string BitMask {get;set;}
        public void SelectedPreScalar(int Select)
        {
            m_controlRegs[0] &= Convert.ToByte(BitMask);
            m_refClock[0] = Convert.ToByte(18432000 * 2); 
        }
