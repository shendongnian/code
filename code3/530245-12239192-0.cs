    public class CreateGameViewModel
    {
        [Required]
        public string SideA { get; set; }
        [Required]
        public string SideB { get; set; }
        [HiddenInput(DisplayValue = false)]
        public List<int> ConfigurableCategoryIDs { get; set; }
    }
