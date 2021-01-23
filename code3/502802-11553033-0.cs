    [Serializable]
    public class LitePropertyData
    {
        public virtual string Description { get; set; }
        public virtual bool DisplayEditUI { get; set; }
        public int OwnerTab { get; set; }
        public virtual string DisplayName { get; set; }
        public int FieldOrder { get; set; }
        public bool IsRequired { get; set; }
        public string Name { get; set; }
        public virtual bool IsModified { get; set; }
        public virtual int ParentPageID { get; set; }
        public LiteDataType Type { get; set; }
        public object Value { get; set; }
    }
    [Serializable]
    public enum LiteDataType
    {
        String,
        NotString,
    }
    [Serializable]
    public class LitePageData
    {
        public String Guid { get; set; }
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Int32? ParentID { get; set; }
        public DateTime Created { get; set; }
        public String CreatedBy { get; set; }
        public DateTime Changed { get; set; }
        public String ChangedBy { get; set; }
        public Int32? LitePageTypeID { get; set; }
        public String Html { get; set; }
        public String FriendlyName { get; set; }
        public Boolean IsDeleted { get; set; }
        public List<LitePropertyData> Properties { get; set; }
        public LiteSeoPageData Seo { get; set; }
    }
    [Serializable]
    public class LiteSeoPageData
    {
        public string Author { get; set; }
        public string Classification { get; set; }
        public string CopyRight { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Title { get; set; }
    }
