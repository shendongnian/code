    [JsonIgnore]
    public bool SomeFlag { get; set; }
    [JsonProperty(nameof(SomeFlag))]
    public int SomeFlagAsInt
    {
        get => SomeFlag ? 1 : 0;
        set => SomeFlag = value > 0;
    }
