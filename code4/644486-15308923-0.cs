    [JsonIgnore]
    [DefaultValue(0)]
    public int? Bar2Int;
    
    public string Bar2
    {
       return { Bar2Int.HasValue ? this.Bar2Int.Value.ToString() : String.Empty; }
    }
