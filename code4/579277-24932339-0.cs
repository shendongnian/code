	public enum Genders
	{
		Male,
		Female
	}
	[ToolboxBitmap(typeof(RadioButton))]
	public partial class GenderRadioButton : RadioButton
	{
		public GenderRadioButton()
		{
			InitializeComponent();
		}
		public GenderRadioButton (IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}
		public Genders gender{ get; set; }
	}
