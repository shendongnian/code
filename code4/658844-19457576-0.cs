    private OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
    private string[] Tokenize(string text)
    {
        if (mTokenizer == null)
        {
            mTokenizer = new OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer(mModelPath + "EnglishTok.nbin");
        }
        return mTokenizer.Tokenize(text);
    }
