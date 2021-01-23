    SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
    Grammar gr = new DictationGrammar();
    sre.LoadGrammar(gr);
    sre.SetInputToWaveFile("C:\\Users\\Soham Dasgupta\\Downloads\\Podcasts\\Engadget_Podcast_353.wav");
    sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
    sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
    sre.EndSilenceTimeout = new TimeSpan(100000000);
    sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000); 
    StringBuilder sb = new StringBuilder();
    while (true)
    {
        try
        {
            var recText = sre.Recognize();
            if (recText == null)
            {               
                break;
            }
               
            sb.Append(recText.Text);
        }
        catch (Exception ex)
        {   
            //handle exception      
            //...
            break;
        }
    }
    return sb.ToString();
