     List<string> TotalLabels = GetAllLabels();
        for (int i = 0; i < TotalLabels.Count; i++)
        {
        if (TotalLabels[i].Contains("closed"))
        {
        TotalLabels.RemoveAt(i);
        i--;
        }
        }
