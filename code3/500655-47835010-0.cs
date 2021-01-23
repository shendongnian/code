    public static string ToStringOrNull(this Nullable<decimal> nullable, string format = null)        
            {
                string resTmp = "";
                if (nullable.HasValue)
                {
                    if (format != null)
                    {
                        resTmp = nullable.Value.ToString(format);
                    }
                    else
                    {
                        resTmp = nullable.ToString();
                    }
                }
                else
                {
                    resTmp = "";
                }
                return resTmp;
            }
