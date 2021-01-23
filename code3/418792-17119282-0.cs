    foreach (string line in bold.Lines)
    {
        int srt = bold.Find(name);
        if (srt > 0)
        {
            bold.Select(srt, name.Length);
            bold.SelectionFont = new System.Drawing.Font(bold.Font, FontStyle.Bold);
        }
    }
