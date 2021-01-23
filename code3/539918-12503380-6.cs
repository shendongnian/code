    public class AttributeComparer : IComparer<Attribute>
    {
        public int Comparer(Attribute x, Attribute y)
        {
            if(x == null) return y == null ? 0 : -1;
            if(y == null) return 1;
            
            if(x is IsInPkAttribute) return (y is IsInPkAttribute) ? 0 : 1;
            else if(y is IsInPkAttribute) return -1;
            else
            {
                xa = (IncludeInEditorAttribute)x;
                ya = (IncludeInEditorAttribute)y;
                
                if(xa.IsReadOnlyOnModify == ya.IsReadOnlyOnModify) return 0;
                else return x.IsReadOnlyOnModify ? 1 : -1;
            }
        }
    }
