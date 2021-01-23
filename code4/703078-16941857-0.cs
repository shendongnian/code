    public class LanguageTemplateSelector : DataTemplateSelector
    { 
    	public DataTemplate ItemTemplate1 { get; set; }
    	public DataTemplate ItemTemplate2 { get; set; }
    
    	protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    	{
    	    string language = Windows.Globalization.ApplicationLanguages.primaryLanguageOverride;
    		
    		if(language.Equals("LanguageTAG"))
    		{
    		     return ItemTemplate1;
    		}
    		else if(language.Equals("AnotherLanguageTAG"))
    		{
    			return ItemTemplate2;
    		}
    		
    		return base.SelectTemplateCore(item, container);
    	}
    }
