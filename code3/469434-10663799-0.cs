    // Names changed for sanity. You could use the VB IsNumeric function, or
    // consider *exactly* what you want - int.TryParse, long.TryParse or
    // decimal.TryParse may be appropriate. Also note that I've changed your "Or"
    // into an "And" as that's the only thing that makes sense...
    return part.Length == ValidPartLength && 
           IsNumeric(part)) &&
           part != new string(part[0], ValidPartLength);
