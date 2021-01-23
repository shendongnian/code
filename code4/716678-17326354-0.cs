    namespace ModbusMaster_2._0
    {
        public partial class Form1 : Form
        {
            ModbusMaster mb = new ModbusMaster();
            public Form1()
            {
                InitializeComponent();
                this.Controls.Add(mb); //Add your usercontrol to your forms control collection
            }
            public void button1_Click(object sender, EventArgs e)
            {
                mb.openPort("wooooo");
            }
        }
    }
