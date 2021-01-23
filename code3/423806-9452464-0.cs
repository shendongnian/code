    public static void SelectPaper(string paperName)
    {
        var paper = ListPapers.FirstOrDefault(paper => paper.PaperName.Equals(paperName));
        if (paper != null)
        {
            paper.IsPending = true;
            PropertyChanged("IsCheckingPending");
        }
    }
