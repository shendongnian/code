    public void SaySomething(string somethingToSay)
    {
        var synth = new System.Speech.Synthesis.SpeechSynthesizer();
        synth.SpeakAsync(somethingToSay);
    }
 
