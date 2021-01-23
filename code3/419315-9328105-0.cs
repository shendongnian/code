    public string[] GetCsVsFromArrayTuned(int[] array, int csvLimit)
    {
        List<string> parts = new List<string>();
        StringBuilder sb = new StringBuilder();
        foreach (int id in array)
        {                
            if (sb.Length + this.GetIntegerDigitCount(id) < csvLimit)
            {
                sb.AppendFormat("{0},", id);
            }
            else
            {
                if (sb.Length > 0)
                {
                    sb.Length--;
                }
    
                parts.Add(sb.ToString());
                sb.Length = 0;
            }
        }
    
        return parts.ToArray();
    }
