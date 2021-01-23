    // Seriously!  Don't do this in production code! Ever!!!
	public class CrazyAdd2 : IDictionary<string, int>
	{
		public int this[string key]
		{
			get { throw new NotImplementedException(); }
			set {Console.WriteLine($"([{key}]={value})"); }
		}
    #region NotImplemented
    // lots of empty methods go here
    #endregion
    }
