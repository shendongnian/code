		.
		.
		.
		MyButton button2 = new MyButton();
		button2.Frame = new RectangleF(20,90,100,50);
		button2.SetTitle("Button 2", UIControlState.Normal);
		button2.Fix();
		AddSubview(button2); // Now drawn correctly before Tap
		.
		.
    public class MyButton : UIButton
	{
		public MyButton() : base(UIButtonType.RoundedRect) { }
		public void Fix() {
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
			Frame = frame;
			TranslatesAutoresizingMaskIntoConstraints = temp;
		}
	}
