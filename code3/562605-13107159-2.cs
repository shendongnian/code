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
        public partial class Form3 : Form
        {
            public Form3()
            {
                InitializeComponent();
            }
            private void Form3_Load(object sender, EventArgs e)
            {
                Timer Timer1 = new Timer(); //Initialize a new Timer object
                Timer1.Tick += new EventHandler(Timer1_Tick); //Link its Tick event to Timer1_Tick
                Timer1.Start(); //Start the timer
            }
            private void ChangeLanguage(string lang)
            {
                foreach (Control c in this.Controls)
                {
                    ComponentResourceManager crm = new ComponentResourceManager(typeof(Form1));
                    crm.ApplyResources(c, c.Name, new CultureInfo(lang));
                }
            }
            private void Timer1_Tick(object sender, EventArgs e)
            {
                if (Form2._ChangeLanguage) //Indicates if ChangeLanguage() requires to be called
                {
                    Form2._ChangeLanguage = false; //Indicates that we'll call the method
                    ChangeLanguage(Form1._Language); //Call the method
                }
            }
        }
    }
