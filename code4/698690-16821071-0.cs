    private void WordApplication_ApplQuit()
    {
        wordGenerator.Dispose();
        wordGenerator = null;
        wh.Set(); // signal that word has closed
    }
