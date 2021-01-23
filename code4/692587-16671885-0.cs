     //delcare an event args clas
     public class LineReceivedEventArgs : EventArgs
    {
        //Data to pass to the event
        public string LineData{get; private set;}
        public LineReceivedEventArgs(string lineData)
        {
            this.LineData = lineData
        }
    }
    //declare a delegate
    public delegate void LineReceivedEventHandler(object sender, LineReceivedEventArgs Args);
    public class PortaSerial  //: IDisposable
    {
        private SerialPort serialPort;
        private Queue<byte> recievedData = new Queue<byte>();
        //add event to class
        public event LineReceivedEventHandler LineReceived;
        public PortaSerial()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += serialPort_DataReceived;
        }
        public void Abrir(string porta, int velocidade)
        {
            serialPort.PortName = porta;
            serialPort.BaudRate = velocidade;
            serialPort.Open();
        }
        public string[] GetPortas()
        {
            return SerialPort.GetPortNames();
        }
        public string[] GetVelocidades()
        {
            return new string[] { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
        }
        void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.Length);
            data.ToList().ForEach(b => recievedData.Enqueue(b));
            processData();
            //raise event here
            if (this.LineReceived != null)
                LineReceived(this, new LineReceivedEventArgs("some line data"));
            
        }
        private void processData()
        {
            // Determine if we have a "packet" in the queue
            if (recievedData.Count > 50)
            {
                var packet = Enumerable.Range(0, 50).Select(i => recievedData.Dequeue());
            }
        }
        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
    public partial class FormPrincipal : Form
    {
        PortaSerial sp1 = new PortaSerial(); // like this command passed LineReceivedEvent or LineReceived
        // event handler method
        void sp1_LineReceived(object sender, LineReceivedEventArgs Args)
        {
            //do things with line
            MessageBox.ShowDialog(Args.LineData);
        }
        public FormPrincipal()
        {
            InitializeComponent();
            //add handler to event
            sp1.LineReceived += new LineReceivedEventHandler(sp1_LineReceived);
            cmbPortas.Items.AddRange(sp1.GetPortas());
            cmbVelocidade.Items.AddRange(sp1.GetVelocidades());
        }
        
    }
