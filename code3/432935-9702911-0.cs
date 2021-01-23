    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace PressdMonitorSrvMod.Custom_Control
    {
        public partial class ProgressBarExtended : UserControl
        {
            //constructor
            public ProgressBarExtended()
            {
                InitializeComponent();
            }
    
            #region Properties
    
            // Create a Value property for the Progress bar
            public float Value
            {
                get { return percent; }
                set
                {
                    // Maintain the Value between 0 and 100
                    if (value < 0) value = 0;
                    else if (value > 100) value = 100;
                    percent = value;
    
                    percentage.Text = string.Format("{0}%", value);
    
                    //change the notch color when overdrawn
                    if (value.Equals(25f))
                        notch25.BackColor = Color.White;
                    else if (value.Equals(50f))
                        notch50.BackColor = Color.White;
                    else if (value.Equals(75f))
                        notch75.BackColor = Color.White;
                    else if (value > 0 && value < 25)
                        notch25.BackColor = notch50.BackColor = notch75.BackColor = ProgressBarColor;
                    else if (value > 25 && value < 50)
                        notch50.BackColor = notch75.BackColor = ProgressBarColor;
                    else if (value > 50 && value < 75)
                        notch75.BackColor = ProgressBarColor;
                    //move the percentage text to the center from start
                    if (percentage.Location.X < ((Width - percentage.Width)/2))
                    {
                        percentage.Location = new Point((int) ((percent/100)*Width) - percentage.Width, 0);
                        percentage.Margin = new Padding(0);
                        percentage.Dock = DockStyle.None;
                        percentage.BorderStyle = BorderStyle.None;
                        percentage.AutoSize = true;
                        percentage.TextAlign = ContentAlignment.BottomCenter;
                    }
                    else
                    {
                        //already in center, keep it in center
                        ProgressBarExtendedSizeChanged();
                    }
                    //redraw after changes
                    Refresh();
                }
            }
    
            public Color ProgressBarColor { get; set; }
    
            public Color HighlightColor { get; set; }
    
            public Font LabelFont
            {
                get { return percentage.Font; }
                set { percentage.Font = value; }
            }
    
            public Color LabelColor
            {
                get { return percentage.ForeColor; }
                set { percentage.ForeColor = value; }
            }
    
            //make it readonly, hide the property
            public new BorderStyle BorderStyle;
    
            #endregion Properties
    
            #region Events
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                // Create a brush that will draw the background of the Progress bar
    
                using (var brush = new SolidBrush(ProgressBarColor))
                    {
                    using (var pen = new Pen(brush))
                        {
                        // Create a linear gradient that will be drawn over the background.
                        using (var lgBrush = new LinearGradientBrush(new Rectangle(-1, -1, Width, Height), 
                            Color.FromArgb(150, highlightColor), 
                            Color.FromArgb(10, ProgressBarColor), 
                            LinearGradientMode.Vertical))
                            {
                            // Calculate how much has the Progress bar to be filled for "x" %
                            var width = (int)((percent / 100) * Width);
                            //draw the progress bar
                            e.Graphics.FillRectangle(brush, 0, 0, width, Height);
                            e.Graphics.FillRectangle(lgBrush, 0, 0, width, Height);
                            //draw the border
                            e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                            }
                        }
                    }
            }
    
            private void ProgressBarExtendedSizeChanged()
            {
                // Maintain the label in the center of the Progress bar
                percentage.Location = new Point(Width/2 - percentage.Width/2, 0);
            }
    
            #endregion Helper Methods
        }
    }
