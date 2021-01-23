    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Globalization;
    
    namespace NameSpaceGoesHere
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public static bool _ChangeLanguage = false; //This will indicate if the void needs to be called
            public static string _Language = ""; //This will indicate our new language
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                ChangeLanguage("fr-FR");
    
            }
    
            private void ChangeLanguage(string lang)
            {
                foreach (Control c in this.Controls)
                {
                    ComponentResourceManager crm = new ComponentResourceManager(typeof(Form1));
                    crm.ApplyResources(c, c.Name, new CultureInfo(lang));
                    _Language = lang; //Sets the language to lang
                    _ChangeLanguage = true; //Indicates that the void needs to be called through the TWO other forms as well
                }
            }
    
        }
    }
