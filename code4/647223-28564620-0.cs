    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Speech.Synthesis; // first import this package
    
        namespace textToSpeech
        {
            public partial class home : Form
            {
                public string s = "pran"; // storing string (pran) to s
            
                private void home_Load(object sender, EventArgs e)
                    {
                        speech(s); // calling the function with a string argument
                    }
                private void speech(string args) // defining the function which will accept a string parameter
                    {
                        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                        synthesizer.SelectVoiceByHints(VoiceGender.Male , VoiceAge.Adult); // to change VoiceGender and VoiceAge check out those links below
                        synthesizer.Volume = 100;  // (0 - 100)
                        synthesizer.Rate = 0;     // (-10 - 10)
                        // Synchronous
                        synthesizer.Speak("Now I'm speaking, no other function'll work");
                        // Asynchronous
                        synthesizer.SpeakAsync("Welcome" + args); // here args = pran
                    }       
             }
        }
