    public event EventHandler<CalculaMontosEventArgs> CantidadesEvent = delegate { };
    public class CalculaMontosEventArgs : EventArgs
	{
		public decimal Total { get; set; }
		public CalculaMontosEventArgs(decimal total)
		{
			Total = total;
		}
	}
