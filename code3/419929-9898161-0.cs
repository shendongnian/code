    // This goes in your application initialization code
    var engine = new SpeechRecognitionEngine();
    // Set event handlers here...
    // Load grammar here...
    // This goes in your code where you open the dialog and want
    // speech recognition
    while (isFileDialogOpen) {
        engine.Recognize(); // It's probably not called 'engine' in your code ;)
    }
