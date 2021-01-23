    public class ChartItem
    {
        public string Title { get; set; } // coil456
        public double Value { get; set; } // 334
        public string TooltipLabel 
        { 
            get { return string.Format("{0}({1})", this.Title, this.Value); } // coil456(334)
        }
    }
