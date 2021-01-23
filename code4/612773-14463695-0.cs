    public class CreateAdViewModel
    {
        public int Operation_Id { get; set; }
        [Display(ResourceType = typeof(HelpResources), Name = "AdViewModel_Price_Label")]
        public decimal? Price { get; set; }
        [Display(ResourceType = typeof(HelpResources), Name = "AdViewModel_MaxPrice_Label")]
        public decimal? MaxPrice { get; set; }
    }
