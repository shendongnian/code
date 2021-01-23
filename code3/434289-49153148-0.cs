    [JsonIgnore]
    public bool SomeFlag { get; set; }
    [JsonProperty(nameof(SomeFlag))]
    public int SomeFlagAsInt
    {
        get => IsOk ? 1 : 0;
        set => IsOk = value > 0;
    }
