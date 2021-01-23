    private DateTime lastModified;
    public String LastModified {
            get { return lastModified.ToString("HH_mm_yyyy"); }
            set 
            { 
                long ms = Int64.Parse(value);
                var date = new DateTime(1970, 1, 1).AddSeconds(ms);
                date = date.ToLocalTime();
                lastModified = date;
            }
        }
