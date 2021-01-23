    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Speech.Recognition;
    using System.Threading;
    
    
    namespace SesTanima
    {
        public partial class Form1 : Form
        {
            private SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                LoadGrammars();
                StartRecognition();
            }
    
            
            private void LoadGrammars() 
            {
                Choices choices = new Choices( new string[] {"Lights on", "Exit", "Zoom out", "Zoom in", "Reset", "Lights off" } );
                GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
                Grammar grammar = new Grammar(grammarBuilder);
                recognizer.LoadGrammar(grammar);
            }
            
    		private void StartRecognition() 
            {
                recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechDetected);
                recognizer.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(recognizer_SpeechRecognitionRejected);
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(recognizer_RecognizeCompleted);
    
            
    			Thread t1 = new Thread(delegate()
                {            
                    recognizer.SetInputToDefaultAudioDevice();
                    recognizer.RecognizeAsync(RecognizeMode.Single);
                });
                t1.Start();
            }
            
    		private void recognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e) 
            {
                textBox1.Text = "Recognizing voice command...";     
            }
            
    		private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) 
            {
                if (e.Result.Text == "Lights on")
                {
                    pictureBox1.Image = Properties.Resources.lightsOn;
                }
                else if (e.Result.Text == "Lights off")
                {
                    pictureBox1.Image = Properties.Resources.lightsOff;
                }
                else if ( e.Result.Text == "Exit" )
                {
                    recognizer.Dispose();
                    Application.Exit();
                    
                }
                else if ( e.Result.Text == "Zoom out" )
                {
                    pictureBox1.Size = new System.Drawing.Size( 135, 107 );
                }
                else if ( e.Result.Text == "Zoom in" )
                {
                    pictureBox1.Size = new System.Drawing.Size( 538, 426 );
                }
                else if ( e.Result.Text == "Reset" )
                {
                    pictureBox1.Size = new System.Drawing.Size( 269, 213 );
                }
                textBox1.Text = e.Result.Text;
            }
            
    		private void recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e) 
            {
                textBox1.Text = "Failure.";
            }
            
    		private void recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e) 
            {
                recognizer.RecognizeAsync();
            }
        }
    }
