    for (int i = 2; i < NumOfPage; i++)
    {
       ie.GoTo(ie.Link(WatiN.Core.Find.ByText(i.ToString())).Url);//Don't need quotes at all.
    }
:)
