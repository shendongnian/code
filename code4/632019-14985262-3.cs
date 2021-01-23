    public class ObjInfo
    {
        public int m_Id { get; set; }
 
        ...
        [Required(ErrorMessage = "Other Obj is required.")]
        [Display(Name = "OtherObj")]
        public int otherObjectId { get; set; }
        public OtherObjInfo m_OtherObj { get; set; }
        ...
    }
