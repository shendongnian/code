    switch ((WaitTime)Enum.Parse(typeof(WaitTime), arg.Replace("/:", string.Empty)))
            {
    
                case WaitTime.Max:
                    {
                        return 0;
    
    
                    }
                case WaitTime.Med:
                    {
                        return 1000;
    
    
    
    
                    }
                case WaitTime.Min:
                    {
                       return 2000;
    
    
                    }
                default: return 0;
    
            }
