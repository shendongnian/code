    private static string GetAncestorNodeAsString(XElement e)
    {
        string ancestorData = string.Empty;
    
        e.AncestorsAndSelf().Reverse().ToList().ForEach(anc =>
        {
            if (ancestorData == string.Empty)
            {
                ancestorData = String.Format("{0}[{1}]", anc.Name, GetElementIndex(anc));
            }
            else
            {
                ancestorData = String.Format("{0}.{1}[{2}]", ancestorData, anc.Name, GetElementIndex(anc));
            }
        });
               
        return ancestorData;
    }
