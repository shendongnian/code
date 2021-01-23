    public class AddressModel
    {
    
         public enum OverrideCode
            {
                N,
                Y,
            }
    
         public List<SelectListItem> OverrideCodeChoices { get {
             return SelectListGenerator.GetEnumsByType<OverrideCode>();
         } }
    }
