    public string GetMessage(params object[] otherValues) 
    {
        var values = new[] { this.FirstName }.Concat(otherValues).ToArray();
        return String.Format(this.Message, values);
    }
