    long outValue;
    //will work, but double conversion
    var result = TheArrayList.Cast<object>()
                .Where(m => Int64.TryParse(m.ToString(), out outValue))
                .Select(m => Convert.ToInt64(m)).ToList();
    //should avoid double Parse, but untested, see Daniel Hilgarth's answer and warnings.
    var result = TheArrayList.Cast<object>()
                .Where(m => Int64.TryParse(m.ToString(), out outValue))
                .Select(m => outValue).ToList();
