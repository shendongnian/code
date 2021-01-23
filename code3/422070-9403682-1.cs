    // Add a reference to System.Web.Extensions
    // using System.Web.Script.Serialization;
    JavaScriptSerializer jss = new JavaScriptSerializer();
    var myClass = new MyClas();
    myClass.doubleVal = 42.00;
    myClass.intVal = 42;
    myClass.stringVal = "The answer";
    MessageBox.Show(jss.Serialize(myClass));
