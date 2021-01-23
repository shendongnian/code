    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("{ Test = ");
        stringBuilder.Append((object) this.<Test>__Field);
        stringBuilder.Append(", Integer = ");
        stringBuilder.Append((object) this.<Integer>__Field);
        stringBuilder.Append(", s = ");
        stringBuilder.Append((object) this.<s>__Field);
        stringBuilder.Append(" }");
        return ((object) stringBuilder).ToString();
    }
