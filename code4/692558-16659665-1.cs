    public List<Tag> Tags { get; set; }
    //just a helper, not required
    public void AddTag(string tagName)
    {
        Tag tag = new Tag { Name = tagName };
        Tags.Add(tag);
    }
