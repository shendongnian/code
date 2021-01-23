    private async void ButtonSR_Click(object sender, RoutedEventArgs e)
    {
      // Create an instance of SpeechRecognizerUI.
      this.recoWithUI = new SpeechRecognizerUI();
    
      // Start recognition (load the dictation grammar by default).
      SpeechRecognitionUIResult recoResult = await recoWithUI.RecognizeWithUIAsync();
    
      // Do something with the recognition result.
      MessageBox.Show(string.Format("You said {0}.", recoResult.RecognitionResult.Text));
    }
