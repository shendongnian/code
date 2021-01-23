    public class IncludeInEditorAttributeComparer : IComparer<Attribute>
        {
            public int Compare(Attribute x, Attribute y)
            {
                //In this case we can assume that
                //won´t have null values
    
                if (x is IsInPkAttribute && !(y is IsInPkAttribute))
                    return -1;
                else if (y is IsInPkAttribute && !(x is IsInPkAttribute))
                    return 1;
                else 
                { 
                    bool xa = (x is IncludeInEditorAttribute ? (x as IncludeInEditorAttribute).IsReadOnlyOnModify : false);
                    bool ya = (y is IncludeInEditorAttribute ? (y as IncludeInEditorAttribute).IsReadOnlyOnModify: false);
    
                    if (xa && !ya)
                        return -1;
                    else if (ya && !xa)
                        return 1;
                    else
                        return 0;
                }
            }
        }
