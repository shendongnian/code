    [MetadataType(typeof(PayrollMarkupMetadata))
    public partial class PayrollMarkup_State
    {
      ...
    }
    public class PayrollMarkupMetadata
    {
        [UIHint("StatesEditor")]
        public string State; // Has to have the same type and name as your model
        // etc.
    }
