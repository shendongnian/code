    [BillGenerator("en-us")]
    public class EnUsGenerateBill : IGenerateBill {}
    [BillGenerator("ru-ru")]
    public class RuRuGenerateBill : IGenerateBill {}
    [BillGenerator("de-de")]
    public class DeDeGenerateBill : IGenerateBill {}
    
    container.GetExports<IGenerateBill, BillGeneratorMetadata>().Single(export => export.Metadata.Locale == "en-us");
