    public class BitwiseDateStamp
    {
        private readonly int _value;
        public BitwiseDateStamp(DateTime dt)
        {
            this._value = dt.Year << 20;
            this._value |= dt.Month << 16;
            this._value |= dt.Day << 11;
            this._value |= dt.Hour << 6;
            this._value |= dt.Minute;
        }
        public BitwiseDateStamp() : this(DateTime.Now)
        {   
        }
        public DateTime ToDateTime()
        {
            int year = this._value >> 20;
            int month = (this._value & 0x000f0000) >> 16;
            int day = (this._value & 0x0000f800) >> 11;
            int hour = (this._value & 0x000007c0) >> 6;
            int minute = this._value & 0x0000003f;
            return new DateTime(year, month, day, hour, minute, 0);
        }
        public override string ToString()
        {
            return this._value.ToString();
        }
    }
