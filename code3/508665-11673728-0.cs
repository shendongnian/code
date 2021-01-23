    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                comboBox1.KeyDown += comboBox1_KeyDown;
            }
            private void comboBox1_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Decimal:
                    case Keys.OemPeriod:
                        LoadComboItems(comboBox1.Text);
                        break;
                    default:
                        break;
                }
            }
            void LoadComboItems(string userInput)
            {
                comboBox1.Items.Clear();
                string lookupName = userInput.Trim();
                if (lookupName.Length > 0)
                {
                    string _globalXML = Application.StartupPath + @"\XMLFile1.xml";
                    XmlReader rdr = XmlReader.Create(_globalXML);
                    while (rdr.Read())
                    {
                        if (rdr.LocalName == lookupName)
                        {
                            string ElementName = "";
                            int eCount = 0;
                            int prevDepth = 0;
                            while (rdr.Read())
                            {
                                if (rdr.NodeType == XmlNodeType.Element)
                                {
                                    ElementName += '.' + rdr.LocalName;
                                    eCount++;
                                }
                                else if (rdr.NodeType == XmlNodeType.EndElement && eCount == rdr.Depth)
                                {
                                    if (rdr.Depth >= prevDepth)
                                    {
                                        comboBox1.Items.Add(lookupName + ElementName);
                                        int pos = ElementName.LastIndexOf('.');
                                        ElementName = ElementName.Substring(0, pos);
                                        prevDepth = rdr.Depth;
                                    }
                                    eCount--; 
                                }
                            }
                        }
                    }
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                    comboBox1.DroppedDown = true;
                }
            }
        }
    }
