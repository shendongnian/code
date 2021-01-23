    public event CantidadesDelegate CantidadesEvent = delegate { };
    public delegate void CantidadesDelegate(object sender, CalculaMontosEventArgs e);
	public class CalculaMontosEventArgs : EventArgs
	{
		public decimal Total { get; set; }
		public CalculaMontosEventArgs(decimal total)
		{
			Total = total;
		}
	}
