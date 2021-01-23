I don't think the code tag is allowed to be by itself, try putting it inside an `<example>` tag, like `<example>var s;</example>`. So this should work:
    /// <summary>
    /// This is the summary 
    /// </summary>
    /// <example>
    /// <code>var s;</code>
    /// </example>
    public string SomeValue { get; set; }
