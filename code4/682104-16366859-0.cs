    public class SerialPortDialog : Form
    {
        public SerialPortDialog()
        {
            InitializeComponent();
            this.Load += SerialPortDialog_Load;
        }
        void SerialPortDialog_Load(object sender, System.EventArgs e)
        {
            if (serial != null)
            {
                serialPortTablePanel.DefaultSerialPort = serial;
            }
        }
        public SerialPortDialog(SerialPort sp) : this()
        {
            this.serial = sp;
        }
        public static SerialPort GetSerialPortDialog(SerialPort sp)
        {
            SerialPort temp = sp;
            using (SerialPortDialog icb = new SerialPortDialog(sp))
            {
                if (icb.ShowDialog() == DialogResult.OK)
                    temp = icb.serialPortTablePanel.InputSerialPort;
            }
            return temp;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.serialPortTablePanel = new SerialPortTablePanel();
            this.serialPortTablePanel.Dock = DockStyle.Fill;
            this.Controls.Add(serialPortTablePanel);
            this.MinimumSize = new System.Drawing.Size(280, 500);
            this.ResumeLayout(false);
        }
        private SerialPortTablePanel serialPortTablePanel;
        private SerialPort serial;
    }
