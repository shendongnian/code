    public class ModelToViewModelConverter : ITypeConverter<UIItem,UIItemViewModel>
        {
            public UIItemViewModel Convert(ResolutionContext context)
            {
                UIItem item = (UIItem)context.SourceValue;
                // Perform your convertion logic 
            }
        }
