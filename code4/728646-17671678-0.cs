    public class A
    {
        [ScaffoldColumn(false)]
        public int OrganizationId { get; set; }
        [Display(Name="OrganizationId")]
        [UIHint("DropDownList")]
        public IEnumerable<SelectListItem> Organizations { get; set; }
    }
