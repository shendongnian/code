    using System.Reflection;
    
    /* Beginning Code */
    
    MemoryStream outputWav = new MemoryStream()
    using (SpeechSynthesizer synth = new SpeechSynthesizer())
    {
    	var mi = synth.GetType().GetMethod("SetOutputStream", BindingFlags.Instance | BindingFlags.NonPublic);
    	var fmt = new SpeechAudioFormatInfo(EncodingFormat.ULaw, 8000, 8, 1, 20, 2, null)
    	mi.Invoke(synth, new object[] { ret, fmt, true, true });
    	synth.Speak("This is a test to stream a different encoding.");
    	
    }
    
    outputWav.Seek(0, SeekOrigin.Begin);
    
    /* End Code */
