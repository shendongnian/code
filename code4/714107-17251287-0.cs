    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Speech.Synthesis;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class SpeachForm : Form
        {
            SpeechSynthesizer _synth;
            
            public SpeachForm()
            {
                InitializeComponent();
    
                _synth = new SpeechSynthesizer();
            }
    
            private void SpeachForm_Load(object sender, EventArgs e)
            {
                // Configure the audio output. 
                _synth.SetOutputToDefaultAudioDevice();
    
                // Speak a string.
                var msg = "The text you want to say.";
                _synth.SpeakAsync(msg);
            }
    
            private void SpeachForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                _synth.SpeakAsyncCancelAll();
                _synth.Dispose();
            }
        }
    }
