    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Dictionary<Prime_Broker, Margin2> myDictionary = new Dictionary<Prime_Broker, Margin2>();
            List<Prime_Broker> brokers = new List<Prime_Broker>();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
              for(Int32 i = 0; i < 5; i++)
              { 
                 Prime_Broker br = new Prime_Broker("Broker " + i.ToString(),
                                                    "Symbol " + i.ToString(),
                                                    "Address " + i.ToString());
                 Margin2 mrg = new Margin2( i, i, i);
                 myDictionary.Add(br, mrg);
                 brokers.Add(br);
              }
              listBox1.DataSource = brokers;
              listBox1.DisplayMember = "Name";
              listBox1.ValueMember = "Name";
            }
    
            private void listBox1_SelectedValueChanged(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex > -1)
                {
                    Prime_Broker selectedBroker = (Prime_Broker)listBox1.SelectedItem;
                    Margin2 margin;
                    if (myDictionary.TryGetValue(selectedBroker, out margin))
                    {
                        textBox1.Text = String.Format("{0}, {1}, {2}",
                                                      margin.Commission,
                                                      margin.Maint,
                                                      margin.Fees);
                    }
                }
            }
        }
    
        public class Prime_Broker
        {
            public string Name { set; get; }
            public string Symbol { set; get; }
            public string Address { set; get; }
    
            public Prime_Broker(string name, string symbol, string address)
            {
                this.Name = name;
                this.Symbol = symbol;
                this.Address = address;
            }
        }
    
        public class Margin2
        {
            public Int32 Maint { set; get; }
            public Int32 Commission { set; get; }
            public Int32 Fees { set; get; }
    
            public Margin2(Int32 maint, Int32 commission, Int32 fees)
            {
                this.Maint = maint;
                this.Commission = commission;
                this.Fees = Fees;
            }
        }
    }
