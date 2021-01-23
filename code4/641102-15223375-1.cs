     public string InternalData { get; set; }
     public double[] Data
     {
        get
        {
            return Array.ConvertAll(InternalData.Split(';'), Double.Parse);                
        }
        set
        {
            _data = value;
            InternalData = String.Join(";", _data.Select(p => p.ToString()).ToArray());
        }
     }
