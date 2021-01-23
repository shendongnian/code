    using namespace System::Speech::Synthesis;
    using namespace System::Speech::Recognition;
    using namespace System::Speech::AudioFormat; 
    //you put a C# code instead of C++/Cli, try this:
    private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
        SpeechSynthesizer^ synth=gcnew SpeechSynthesizer();
        synth->Rate = -2;
        synth->Volume = 100;
        synth->Speak("She say: This is real C++/Cli");
    }
    
