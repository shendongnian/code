    while (true)
    {
       using (SpeechSynthesizer tts = new SpeechSynthesizer())
       {
          Console.WriteLine("Speaking..."); 
          tts.Speak(pb);
          //Print private working set sieze
          Console.WriteLine("Memory: {0} KB\n",(Process.GetCurrentProcess().PrivateMemorySize64 / 1024).ToString("0"));
       }
    }
