    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.IO;
    
    namespace mycard
    {
        public partial class Form1 : Form
        {
            byte[] memo = new byte[256];
            byte[] buffer = new byte[255];
            
            //private SerialPort serialPort = new SerialPort();
            //We don't need this object. We never configure it, it's not the 
            //same object which you use to write 'eject bytes'!
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
               //subscribe on data received event here. IMPORTANT: we 'listen' s1 object here!
                s1.DataReceived += 
                    new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
    
            //open port
            private void button1_Click(object sender, EventArgs e)
            {
                if (s1.IsOpen)
                {
                    s1.Close();
                }
                s1.Open();
            }
       
            //Eject order which is working fine
            private void button1_Click_1(object sender, EventArgs e)
            {
                byte[] data= new byte[4];
    
                memo[0]=0x60;
                memo[1]=0x00;
                memo[2]=0x02;
                memo[3]=0x43;
                memo[4]=0x31; //32
                memo[5]=0x10; //13
    
                s1.Write(memo,0,6);
            }
    
            //close port
            private void button2_Click(object sender, EventArgs e)
            {
                s1.Close();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                txtDataReceived.Text = "\r\n";
            }
    
            public void updateTextBox()
            {
                byte[] buffer = new byte[255];
    
    	        //we must read from s1, not from serealPort!!!
                s1.Read(buffer, 0, 4);
                txtDataReceived.Text = (buffer[0].ToString() + Environment.NewLine 
                    + buffer[1].ToString() + Environment.NewLine 
                    + buffer[2].ToString() + Environment.NewLine 
                    + buffer[3].ToString() + Environment.NewLine);
            }
    		
    		//data received, let's read it!
    		private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
              updateTextBox(); 
            }
        }
    }
