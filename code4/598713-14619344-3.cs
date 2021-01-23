	public class MyButton : UIButton
	{
		public MyButton() : base(UIButtonType.RoundedRect) { }
		public override RectangleF Frame {
			get {
				return base.Frame;
			}
			set {
				var temp = TranslatesAutoresizingMaskIntoConstraints;
				TranslatesAutoresizingMaskIntoConstraints = false;
				var constraints = new [] {
					NSLayoutConstraint.Create(this, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, value.Width),
					NSLayoutConstraint.Create(this, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, value.Height)
				};
				AddConstraints(constraints);
				SizeToFit();
				RemoveConstraints(constraints);
				base.Frame = value;
				TranslatesAutoresizingMaskIntoConstraints = temp;
			}
		}
	}
