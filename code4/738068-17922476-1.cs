    public class SopFolder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int Status { get; set; }
        public virtual ICollection<SopField> SopFields { get; set; }
    
        //public virtual ICollection<SopFolder> SopFolderChildrens { get; set; }
        public int? ParentFolderId { get; set; }
    
        public virtual ICollection<SopBlock> Blocks { get; set; }
        public virtual ICollection<SopReview> Reviews { get; set; }
    }
