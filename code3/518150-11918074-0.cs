    using System;
    using System.Windows.Forms;
    using System.Xml;
    
    namespace UpdateXmlRecord
    {
        public partial class Form1 : Form
        {
            private XmlDocument xDoc;
    
            public Form1()
            {
                InitializeComponent();
                xDoc = new XmlDocument();
                xDoc.Load("file.xml");
            }
    
            /// <summary>
            /// Retrieve Xml Node
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button1_Click(object sender, EventArgs e)
            {
                string id = txtId.Text;
                string fName = "", lName = "";
                foreach (XmlElement element in xDoc.DocumentElement)
                {
                    if (element.Name == "Customer" && element.Attributes["id"].Value == id)
                    {
                        foreach (XmlNode node in element)
                        {
                            if (node.Name == "FirstName")
                            {
                                fName = node.InnerText;
                            }
    
                            if (node.Name == "LastName")
                            {
                                lName = node.InnerText;
                            }
                        }
                    }
                }
    
                txtFName.Text = fName;
                txtLName.Text = lName;
            }
    
            /// <summary>
            /// Save Xml Node With Custom Value
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button2_Click(object sender, EventArgs e)
            {
                string id = txtId.Text;
                foreach (XmlElement element in xDoc.DocumentElement)
                {
                    if (element.Name == "Customer" && element.Attributes["id"].Value == id)
                    {
                        foreach (XmlNode node in element)
                        {
                            if (node.Name == "FirstName")
                            {
                                node.InnerText = txtFName.Text;
                            }
    
                            if (node.Name == "LastName")
                            {
                                node.InnerText = txtLName.Text;
                            }
                        }
                    }
                }
                xDoc.Save("file.xml");
            }
        }
    }
