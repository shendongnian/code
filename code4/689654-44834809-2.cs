	public class tests_OwnApp : IndicatorObject {
        public tests_OwnApp(object _ctx):base(_ctx)
        {
            PortNumber = 5000;
        }
        [Input]
        public int PortNumber { get; set; }
        public static string Symbol;
        const string ServerIP = "127.0.0.1";
		
        IPAddress localAdd;
        TcpListener listener;
        TcpClient client;
        NetworkStream nwStrm;
        private IPlotObject plot1;
		
		protected override void Create() {
			// create variable objects, function objects, plot objects etc.
			plot1 = AddPlot(new PlotAttributes("", EPlotShapes.Line, Color.Red));
            localAdd = IPAddress.Parse(ServerIP);
            client = null;
		}
		
		protected override void StartCalc() {
            // assign inputs 
            // establish connection
            if (listener == null)
            {
                listener = new TcpListener(localAdd, PortNumber);
            }
			listener.Stop();
			Thread.Sleep(100);
            listener.Start();
        }
        protected override void CalcBar()
        {
            // indicator logic 
            if (Bars.LastBarTime <= Bars.Time[0] + new TimeSpan(2,0,0))
            {
                Symbol = Bars.Info.Name;
                
                if (client == null || !client.Connected)
                    client = listener.AcceptTcpClient();
                // create network stream
                nwStrm = client.GetStream();
                // send symbol to app:
                Output.WriteLine("sending " + Symbol + " to application");
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(Symbol);
                
                string closingPrice = Convert.ToString(Bars.Close[0]);
                string totalMsg = "Sym," + Symbol +
                    "\nClose[0]," + closingPrice + "\nClose[1]," + Bars.Close[1].ToString();
                byte[] bytes2 = ASCIIEncoding.ASCII.GetBytes(totalMsg);
                nwStrm.Write(bytes2, 0, bytes2.Length);
            }
        }
	}
