    public partial class PRODUCT
    {
        public int ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public int CATEGORY_ID { get; set; }
        public string LANGUAGE { get; set; }
        **public int SelectedCATEGORY_ID { get; set; }**
    }
    @Html.DropDownListFor(**model=>model.SelectedCATEGORY_ID** , new  SelectList(ViewBag.ProductCategoryData, "Value", "Text"))  
