    [MetadataType(typeof(BookingTypeMetaData))]
    public class Test : BookingType {
        public Test() {
            
        }
    }
    public class BookingTypeMetaData {
        [Required]
        [Display(Name = "People Count")]
        public int PeopleOnTourCount { get; set; }
    }
