    class OfficeComparer:IComparer<Office>
    {
            int IComparer.Compare(Office a, Office b)
            {
                   if ( a.Office.Country != null && b.Office.Country != null) 
                           return a.Office.Country.CompareTo(b.Office.Country);
                   if ( a.Office.Country == null && b.Office.Country != null) return -1;
                   if ( a.Office.Country != null && b.Office.Country == null) return 1;  
                   return 0; // if both have no country, return equal or whatever other criteria comparaison
                   
            }
    }
