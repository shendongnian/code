    ...
	public class CustomView: UIView
	{
		public CustomView ()
		{
		}
		public override void Draw (System.Drawing.RectangleF rect)
		{
			base.Draw (rect);
			var context = UIGraphics.GetCurrentContext();
			DrawCenteredTextAtPoint(UIGraphics.GetCurrentContext(), 50, 10, "adsasdasd", 20);
		}
    ...
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			v = new CustomView();
			v.BackgroundColor = UIColor.Red;
			View.AddSubview(v);
			v.Frame = new RectangleF(0, 100, 320, 100);
    ...
