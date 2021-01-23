    using OpenNLP.Tools.SentenceDetect;
    // ...
            
    EnglishMaximumEntropySentenceDetector sentenceDetector = 
      new EnglishMaximumEntropySentenceDetector(mModelPath + "EnglishSD.nbin");
    string[] sentences = sentenceDetector.SentenceDetect(input);
