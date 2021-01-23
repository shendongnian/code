    using System.Speech.Synthesis;
    namespace TextToSpeech
    {
       public partial class Form1 : Form
       {
         SpeechSynthesizer speak;
         public Form1()
         {
            InitializeComponent();
            speak = new SpeechSynthesizer();
         }
    
         private void button1_Click(object sender, EventArgs e)
         {
            string text="Speak this";
            speak.SpeakAsync(text);
         }
      }
    }
