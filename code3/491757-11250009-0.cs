	class ProcessingParams // Or use a Tuple<int, int, int>
	{
		public int A { get; set; }
		public int B { get; set; }
		public int C { get; set; }
	}
	BlockingCollection<int> bc = new BlockingCollection<int>();
	private int Processing() { 
		try
		{
			while (true) 
			{
				ProcesingParams params = bc.Take();			
			   this.A = this.moreProcessing(params.A);
			   this.B = this.moreProcessing(params.B);
			   this.C = this.moreProcessing(params.C);
			   int newInt = /* ... */
			   return newInt; // Rather than 'return' the int,  place it in this.MyTextBox.Content using thread marshalling
			}
		}
		catch (InvalidOperationException)
		{
			// IOE means that Take() was called on a completed collection
		}
	}
	public void Button_Click(object sender, EventArgs args) {
	   //var result = Processing(1, 2, 3);
	   bc.Add (new ProcessingParams() { A = 1, B = 2, C = 3 };
	   //this.MyTextBox.Content = result;
	}
