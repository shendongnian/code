    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    namespace StackOverflow
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool doFileOpenFirst = true;
            if (doFileOpenFirst)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.CheckFileExists = true;
                dialog.Filter = "Image files|*.bmp;*.jpg;*.png";
                dialog.ShowDialog();
            }
            // Just write a trivial XML file
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);// Create the root element
            XmlElement root = doc.CreateElement("Database");
            doc.AppendChild(root);
            doc.Save("Trivial.xml");
        }
    }
    }
