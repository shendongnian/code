    [DataContract]
    public class CategoryEntity : Category
    {
        [DataMember]
        public int ActiveAdsCount { get; set; }
        [DataMember]
        public int DisplaySequence { get; set; }
        [DataMember]
        public IList<CategoryEntity> SubCategories { get; set; }
        [DataMember]
        public IList<BasicCategoryInfo> SubCategoriesBasicInfoList { get; set; }
        [DataMember]
        public string ParentCategoryNameEn { get; set; }
        [DataMember]
        public int CityID { get; set; }
    }
