    public partial class LabelEx : Label {
    
    public LabelEx() {
        InitializeComponent();
    }
    protected override void OnPaint(PaintEventArgs e) {
        // Draw the formatted text string to the DrawingContext of the control.
        //base.OnPaint(e);
        Font font = new Font("Tahoma", 48f, FontStyle.Bold);
        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height + 5), Color.Gold, Color.Black, LinearGradientMode.Vertical);
        e.Graphics.DrawString(Text, font, brush, 0, 0);
    }
    
    }
