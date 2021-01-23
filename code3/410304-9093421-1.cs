    // Not mapped class!
    public abstract BaseCase<T> where T : question
    {
        ICollection<T> Questions { get; set; }
    }
    // Mapped entities
    public Case : BaseCase<Question> { }
    public Case2 : BaseCase<InheritedQuestion> { }
