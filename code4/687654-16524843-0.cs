     public class SettingsViewModel
     {
         public int LanguageId { get; set; }
         public SelectList Language { get; set; }
         public int? DefaultLanguageId {get; set;}
     
     
     public SettingsViewModel()
     {
     
     }     
     public SettingsViewModel(int? defaultLanguageId)
     {
         DefaultLanguageId = defaultLanguageId;
     }
     
     private void CreateSelectList SelectListItem()
     {
        List<SelectListItem> list = new List<SelectListItem>();
        var x = 0;
        foreach (var lang in Enum.GetValues(typeof(ResourceHandler.Languages)))
        {
            list.Add(new SelectListItem { Selected = x == langInt, Value = x++.ToString(),   Text = lang.ToString() });
        
        
        if(DefaultLanguageId != null)
           SelectList = new SelectList(list, "Value", "Text", DefaultLanguageId)
        else
           SelectList = new SelectList(list, "Value", "Text") 
       }
    }    
