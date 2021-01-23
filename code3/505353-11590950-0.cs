    public class ProductEditModelConfiguration : ModelMetadataConfiguration<ProductEditModel>
    {
        public ProductEditModelConfiguration()
        {
            Configure(model => model.Id).Hide();
    
            Configure(model => model.Name).DisplayName(() => LocalizedTexts.Name)
                .Required(() => LocalizedTexts.NameCannotBeBlank)
                .MaximumLength(64, () => LocalizedTexts.NameCannotBeMoreThanSixtyFourCharacters);
    
            Configure(model => model.Category).DisplayName(() => LocalizedTexts.Category)
                .Required(() => LocalizedTexts.CategoryMustBeSelected)
                .AsDropDownList("categories", () => LocalizedTexts.SelectCategory);
    
            Configure(model => model.Price).DisplayName(() => LocalizedTexts.Price)
                .FormatAsCurrency()
                .Required(() => LocalizedTexts.PriceCannotBeBlank)
                .Range(10.00m, 1000.00m, () => LocalizedTexts.PriceMustBeBetweenTenToThousand);
        }
    }
