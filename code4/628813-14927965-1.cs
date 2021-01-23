    namespace wfats2
    
    {
      
      public partial class Form1 : Form
        
    {
           
     public Form1()
    
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                XmlDocument doc1 = new XmlDocument();
                doc1.Load("http://api.wunderground.com/api/your_key/conditions/q/92135.xml");
                XmlElement root = doc1.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/response/current_observation");
    
                foreach (XmlNode node in nodes)
                {
                    string tempf = node["temp_f"].InnerText;
                    string tempc = node["temp_c"].InnerText;
                    string feels = node["feelslike_f"].InnerText;
    
                    label2.Text = tempf;
                    label4.Text = tempc;
                    label6.Text = feels;
                }
    
    
    
            }
        }
    }
