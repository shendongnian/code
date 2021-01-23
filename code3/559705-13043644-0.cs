    public void Build(string sInputFileName, CancellationToken cancel, IProgress<int> progress)
    {
      using (StreamReader reader = new StreamReader(sInputFileName))
      {
        int nLine = 0;
        int nTotalLines = CountLines(sInputFileName);
        while ((sLine = reader.ReadLine()) != null)
        {
          nLine++;
          // do something here...
          cancel.ThrowIfCancellationRequested();
          if (progress != null) progress.Report(nLine * 100 / nTotalLines);
        }
        return nLine;
      }
    }
