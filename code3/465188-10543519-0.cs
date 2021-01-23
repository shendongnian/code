    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin
        {
            get { return Color.FromArgb(128, Color.Black); }
        }
    
        public override Color MenuStripGradientEnd
        {
            get { return Color.FromArgb(128, Color.Black); }
        }
    
        public override Color ButtonSelectedHighlight
        {
            get { return Color.FromArgb(64, Color.Black); }
        }
        // etc
    }
