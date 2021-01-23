    public partial class TranspBackground : UserControl
	{
		public TranspBackground()
		{
			InitializeComponent();
		}
		GraphicsPath GrPath
		{
			get
			{
				GraphicsPath grPath = new GraphicsPath();
				grPath.AddEllipse(this.ClientRectangle);
				return grPath;
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			// set the region property to the desired path like this
			this.Region = new System.Drawing.Region(GrPath);
			// other drawing goes here
			e.Graphics.FillEllipse(new SolidBrush(ForeColor), ClientRectangle);
		}
	}
