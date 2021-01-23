    public struct HairColorStruct
    {
        private string m_hairColor;
        public void Update()
        {
            // do whatever you need to do here...
        }
        // the very basic operator overloads that you would need...
        public static implicit operator HairColorStruct(string color)
        {
            var result = new HairColorStruct();
            result.m_hairColor = color;
            return result;
        }
        public static explicit operator string(HairColorStruct hc)
        {
            return hc.m_hairColor;
        }
        public override string ToString()
        {
            return m_hairColor;
        }
        public static bool operator ==(HairColorStruct from, HairColorStruct to)
        {
            return from.m_hairColor == to.m_hairColor;
        }
        public static bool operator ==(HairColorStruct from, string to)
        {
            return from.m_hairColor == to;
        }
        public static bool operator !=(HairColorStruct from, HairColorStruct to)
        {
            return from.m_hairColor != to.m_hairColor;
        }
        public static bool operator !=(HairColorStruct from, string to)
        {
            return from.m_hairColor != to;
        }
    }
