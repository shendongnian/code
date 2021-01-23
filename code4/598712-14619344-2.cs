	public class MyButton : UIButton
	{
		public MyButton() : base(UIButtonType.RoundedRect) { }
		public override RectangleF Frame {
			get {
				return base.Frame;
			}
			set {
				base.Frame = value;
				Fix();
			}
		}
		private void Fix() {
			var frame = this.Frame;
			var temp = TranslatesAutoresizingMaskIntoConstraints;
			TranslatesAutoresizingMaskIntoConstraints = false;
			var constraints = new [] {
				NSLayoutConstraint.Create(this, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, frame.Width),
				NSLayoutConstraint.Create(this, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, frame.Height)
			};
			AddConstraints(constraints);
			SizeToFit();
			RemoveConstraints(constraints);
			base.Frame = frame;
			TranslatesAutoresizingMaskIntoConstraints = temp;
		}
	}
