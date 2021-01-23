    using System;
    using System.Collections.Generic;
    using System.ComponentModel; 
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
 
    namespace VapixForToroRosso
    {
    public partial class Form1 : Form
    {
        private string USER = "root";
        private string PASS = "Blescia";
        private string IP = "192.168.1.2";
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            axAxisMediaControl1.Volume = 100; //Set the volume of speaker
            /*
             *Use this if the camera required the login
             */
            axAxisMediaControl1.MediaUsername = USER; //Set the username
            axAxisMediaControl1.MediaPassword = PASS; //Set the password
            axAxisMediaControl1.Mute = false; //Disable Mute    
            axAxisMediaControl1.EnableReconnect = true; //Reconnect to the camera automatically
 
            axAxisMediaControl1.MediaURL = "rtsp://192.168.1.2/mpeg4/media.amp"; //For Retrieve the video streaming
            axAxisMediaControl1.AudioConfigURL = "http://" + IP + "/axis-cgi/view/param.cgi?camera=1&action=list&group=Audio,AudioSource.A0"; //Pre-Configuration of Camera
            axAxisMediaControl1.AudioTransmitURL = "http://" + IP + "/axis-cgi/audio/transmit.cgi"; //Url to send the streaming AUDIO          
 
            axAxisMediaControl1.Play();
        }
 
        private void btnStartStreaming_Click(object sender, EventArgs e)
        {
            axAxisMediaControl1.AudioTransmitStart(); //Start the streaming to camera
        }
 
        private void btnStopStreaming_Click(object sender, EventArgs e)
        {
            axAxisMediaControl1.AudioTransmitStop(); //Stop the streaming the camera
        }
       }
    }
