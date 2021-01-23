	class MyButton : UIButton {
		UIView input_view;
		public override UIView InputView {
			get {
				if (input_view == null)
					return base.InputView;
				return input_view;
			}
		}
		public void SetInputView (UIView view)
		{
			input_view = view;
		}
	}
