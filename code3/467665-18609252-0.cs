     private static RecognizerInfo GetKinectRecognizer()
            {
                foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
                {
                    System.Diagnostics.Debug.Write(recognizer.Culture.Name+"\n\n");
                    //string value;
                    //recognizer.AdditionalInfo.TryGetValue("Kinect",out value);
                    if ("en-US".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return recognizer;
                    }
    
                }
                
                return null;
            }
