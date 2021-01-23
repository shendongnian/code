	struct SampleClass
	{
		public string Text { get; set };
		public override string ToString() { return Text; }
	}
	var x = new SampleClass{ Text = "Hello" };
	object o = x;
	x.Text = "World";
	MessageBox.Show( string.Format( "{0} {1}", x, o ) );
