    // Handle the SpeechRecognized event. 
	void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
	{
	  //... Code handling the result
	  // Display the recognition alternates for the result.
	  foreach (RecognizedPhrase phrase in e.Result.Alternates)
	  {
		Console.WriteLine(" alt({0}) {1}", phrase.Confidence, phrase.Text);
	  }
	}
