    public class PrePoolOwnerModel
    {
        ....
        public String OglDateEffectiveValue { get; set; }
        ....
    }
    public ViewResult Index(int id)
    {
        ....
        model.OglDateEffectiveValue = model.OglDateEffective.HasValue ? 
                                      model.OglDateEffective.Value.ToString("MM/dd/yyyy") : 
                                      String.Empty;
        ....
    }
