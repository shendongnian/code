    public abstract class Rule {
       protected ComparePopup Popup { get; private set; }
       protected Rule(ComparePopup popup) {
         Popup = popup;
       }
       public abstract bool CheckRule(SystemInfo expected, SystemInfo comp);
    }
    public class BrandingRule : Rule {
       public BrandingRule(ComparePopup popup) : base(popup) { }
       public override bool CheckRule(SystemInfo expected, SystemInfo comp) {
         var result = expected.branding == comp.branding;
         if(!result)
           Popup.addDataToTable("Branding", comp.getBranding() + "", expected.getBranding() + "");
       }
    }
