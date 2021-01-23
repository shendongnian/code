    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ConsoleHelloWorld; //Program.Hello;
    
    
    namespace WindowsFormHelloWorld
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                string word = ConsoleHelloWorld.Program.Hello.words;
                label1.Text = word;
               
            }
        }
    }
