    public MetaTitle { get; set; }
    public MetaDescription { get; set; }
    public MetaKeywords { get; set; }
    ...
    var tag = new HtmlMeta();
    tag.Name = "description";
    tag.Content = MetaDescription;
    this.Header.Controls.Add(tag);
