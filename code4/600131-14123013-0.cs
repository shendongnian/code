    public class HeightAdjustedExtension : MarkupExtension
    {
        public string Height { get; set; }
    
        public HeightAdjustedExtension () { }
    
        public HeightAdjustedExtension (string height)
        {
            Height = height;
        }
           
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            int theheight;
            int.TryParse( Height, out theheight );
    
            double ScreenHeight = (int)Window.Current.Bounds.Height;
            double factor = 1050/(double)theheight ;
            return (int)(ScreenHeight/factor);        
        }
    }
