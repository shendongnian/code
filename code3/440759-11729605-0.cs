    public static void ForceCloseAll(Visio.Documents docs)
    {
        while (docs.Count > 0)
        {
           docs.Application.ActiveDocument.Saved = true;
           docs.Application.ActiveDocument.Close();
        }
    }
