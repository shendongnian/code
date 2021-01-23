    return message
           .Properties
           .AsEnumerable()
           .Any(p => 
                {
                    var val = 0;
                    if(int.TryParse(p.Value, out val))
                    {
                        return p.Key == name &&
                               val >= values[0] &&
                               val <= values[1])
                    }
                    else
                    {
                        return false;
                    }
               );
