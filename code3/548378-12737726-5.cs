    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadControls();
        }
        private void LoadControls()
        {
            for (int i = 0; i < 3; i++)
            {
                flPanel.Controls.Add(new Dynamic());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlTextWriter writer = new XmlTextWriter(@"C:\Temp\Operation.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Operation");
            writer.WriteStartElement("OperationInfo");
            writer.WriteStartElement("OperationName");
            writer.WriteString("Sample operation name");
            writer.WriteEndElement();
            writer.WriteStartElement("OperationDate");
            writer.WriteString(DateTime.Now.ToString("dd-MM-yyyy"));
            writer.WriteEndElement();
            writer.WriteStartElement("FC");
            writer.WriteString("Someone");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("Pilots");
            foreach (var ctrl in flPanel.Controls)
            {
                if (ctrl is IData)
                {
                    writer.WriteStartElement("Pilot");
                    var data = ctrl as IData;
                    writer.WriteStartElement("PilotName");
                    writer.WriteString(data.PilotName);
                    writer.WriteEndElement();
                    writer.WriteStartElement("Ship");
                    writer.WriteString(data.Ship);
                    writer.WriteEndElement();
                    writer.WriteStartElement("StartTime");
                    writer.WriteString(data.StartTime.ToString("hh:mm"));
                    writer.WriteEndElement();
                    writer.WriteStartElement("EndTime");
                    writer.WriteString(data.EndTime.ToString("hh:mm"));
                    writer.WriteEndElement();
                    writer.WriteStartElement("Pay");
                    writer.WriteString(data.Rate.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("XML File created!");
        }
        
    }
