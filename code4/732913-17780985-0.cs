	public class Helper
		{
		public bool A { get; set; }
		public bool B { get; set; }
		public bool C { get; set; }
		public List<Action<bool>> Setters { get; set; }
		public Helper()
			{
			this.Setters = new List<Action<bool>>() 
                { b => this.A = b, b => this.B = b, b => this.C = b };
			}
		public void SetToFalse(IEnumerable<Action<bool>> setters)
			{
			// try to set A, B, C to false in a for loop
			foreach (var a in setters)
				{
				a(false);
				}
			}
		}
