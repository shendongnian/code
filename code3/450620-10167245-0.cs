    public Test(Rule rule)
    {
        if (rule == Rule.Custom)
        {
            throw new ArgumentOutOfRangeException("rule", "A custom rule is not allowed");
        }
        this.rule = rule;
    }
    public Test(Rule rule, string extra)
    {
        if (rule != Rule.Custom)
        {
            throw new ArgumentOutOfRangeException("rule", "Only a custom rule is allowed");
        }
        this.rule = rule;
        this.extra = extra;
    }
