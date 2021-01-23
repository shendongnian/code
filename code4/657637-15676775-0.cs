    private static readonly System.Collections.ObjectModel.ReadOnlyDictionary<string, string> _msgDictionary =
        new System.Collections.ObjectModel.ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>()
            {
                { "MSG_1", "New error {0}" },
                { "MSG_2", "Random error occurred {1}" }
            });
    
    public static System.Collections.ObjectModel.ReadOnlyDictionary<string, string> Messages
    {
        get { return _msgDictionary; }
    }
