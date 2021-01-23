    public class ModelBase
    {
        public string PropertyOne { get; set; }
        public string PropertyTwo { get; set; }
    }
    public class InheritedModelOne : ModelBase
    {
        public string PropertyThree { get; set; }
    }
     
    public class testObject
    { 
        [HttpPost]
        public ActionResult ActionOne(ModelBase formData)
        {
            formData.PropertyOne = "";
            formData.PropertyTwo = "";
            // This is not accessible to ModelBase
            //modelBase.PropertyThree = "";
            return null;
        }
        [HttpPost]
        public ActionResult ActionOne(InheritedModelOne inheritedModelOne)
        {
            // these are from the Base
            inheritedModelOne.PropertyOne = "";
            inheritedModelOne.PropertyTwo = "";
            // This is accessible only in InheritingModel
            inheritedModelOne.PropertyThree = "";
            return null;
        }
         
    }
