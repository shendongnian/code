    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Resources;
    using System.Media;
    using Alarm.Properties; //Required to call 'Resources' directly
    
    namespace Alarm
    {
        public partial class Form1 : Form
        {
            private bool estado = false;
            private SoundPlayer sonido;
    
            public Form1()
            {
                InitializeComponent();
                //ResourceManager resources = new ResourceManager(typeof(Form1)); //We do not actually need this
                sonido = new SoundPlayer(Resources.alarma); //Initialize a new SoundPlayer linked to our sound file (or Alarm.Properties.Resources.alarma if Alarm.Properties was not imported)
                sonido.Play(); //Required if you would like to play the file
            }
        }
    }
