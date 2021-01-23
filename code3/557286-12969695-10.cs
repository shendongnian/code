        public int ID {get;set;}
        public void SelectedPreScalar(int Select)
        {
            int bitMask;
            bitMask = (0 == ID) ? 0xCF : 0x3F; 
            m_controlRegs[0] &= Convert.ToByte(bitMask);
            m_refClock[0] = Convert.ToByte(18432000 * 2); 
        }
