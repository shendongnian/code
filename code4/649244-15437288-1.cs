	public Form3 : Form
	{
		public Form1 Parent { get; set; }
        // TODO: Replace object with the proper type.
		public object SomeComboboxValue
		{
                        // TODO: Replace with the value you want to access.
			get { return SomeComboBox.PropertyYouWantToAccess; }
		}
		
		public Form3()
		{
			InitializeComponent();
		}
		
		public Form3(Form1 form1)
		{
			InitializeComponent();
			Parent = form1; 
		}
	}
	public Form1 : Form
	{
		private Form3 _form3;
		public Form1()
			:this(new Form3())
		{
		}
		
		public Form1(Form3 form3)
		{
			_form3 = form3;
			_form3.Parent = this;
		}
	}
