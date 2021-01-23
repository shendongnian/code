        if (TextboxesDoNotMatch() || TextboxesAreNotEmpty())
        {
            sb2 = tbStartBreak2.Text;
            se2 = tbStartBreak2.Text;
        }
    private bool TextboxesDoNotMatch()
    {
        return tbStartBreak2.Text != tbEndBreak2.Text;
    }
    private bool TextboxesAreNotEmpty()
    {
        return tbStartBreak2.Text != string.Empty && tbEndBreak2.Text != string.Empty;
    }
