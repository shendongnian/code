    public class PackageModel
    {
        public IEnumerable<SelectListItem> Allcategories { get; set; }
        public string CategoryName { get; set; }
    }
    @Html.DropDownListFor(m => m.CategoryName, Model.Allcategories, Model.Package.Category)
