    using System;
    using System.Windows.Forms;
    using System.Reflection;
    namespace DynamicProp
    {
        public partial class Form1 : Form
        {
            class Messagage 
            {
                public string ID { get; set; }
                public string Property1 { get; set; }
                public string Property2 { get; set; }
                public string Property3 { get; set; }
                public string Property4 { get; set; }
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string[] data = { "hasan", "osman", "ali", "veli", "deli" };
    
                Messagage message = new Messagage();
                PropertyInfo[] ozellikler = message.GetType().GetProperties();
                int I=0;
                foreach (PropertyInfo ozellik in ozellikler)
                {
                    ozellik.SetValue(message, data[I], null);
                    listBox1.Items.Add("özellik :" + ozellik.Name + "  tipi :"+ozellik.GetValue(message,null).ToString());
                    I++;
                }
            }
        }
    }
