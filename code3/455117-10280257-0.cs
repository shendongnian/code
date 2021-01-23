        public bool allUniqueRows()
        {
            var distinctCount =  from r in ParetoGrid.Rows
    select r.whateverElement.Distinct().Count();
         if(distinctCount == ParetoGrid.Rows.Count())
        {
        return true;
        }
        else
        {
        return false;
        }
        }
 
