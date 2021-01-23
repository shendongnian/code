    public class ChartItem
    {
        public string Title { get; set; }
    
        public double Value { get; set; }
    
        public string TooltipLabel 
        { 
            get { return string.Format("{0}({1})", this.Title, this.Value); } 
        }
    
        public SolidColorBrush ColumnBrush
        {
            get 
            { 
                if (this.Value < 200)
                {
                    return Brushes.Red;
                }
                else if (this.Value < 350)
                {
                    return Brushes.Yellow;
                }
                else
                {
                    return Brushes.Green;
                }
            } 
        }
    }
