    using System.Drawing;
    public class SlotData
    {
        private PointF _one;
        private PointF _two;
        internal SizeF Skew {get; set;}
        public PointF One 
        {
            get
            {
                return PointF.Add(_one, Skew);
            }
            set {_one = value; }
        }
        public PointF Two 
        {
            get
            {
                return PointF.Add(_two, Skew);
            }
            set {_two = value; }
        }
    }
    public class SlotGroup : List<SlotData>
    {
        internal SizeF Skew
        {
            set
            {
                foreach(var slotData in this)
                {
                    slotData.Skew = value;
                }
            }
        }
    }
    public class ClientData : List<SlotGroup>
    {
        private SizeF _skew;
        public SizeF Skew
        {
            get { return _skew; }
            set
            {
                _skew = value;
                foreach (var slotGroup in this)
                {
                    slotGroup.Skew = value;
                }
            }
        }
    }
