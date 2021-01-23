    // you need to reference System.Web.Extensions
    using System.Web.Script.Serialization;
    
    var jsonSerialiser = new JavaScriptSerializer();
    var json = jsonSerialiser.Serialize(aList);
