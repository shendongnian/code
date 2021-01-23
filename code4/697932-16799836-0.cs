    public class AdjusterLanguageModel
    {
      public Guid LanguageId { get; set; }
      List<SelectListItem> ForeignLanguages{ get; set; }
    }
    
    public class AdjusterListModel
    {
      public List<AdjusterLanguageModel> AdjusterLanguages { get; set }
    }
