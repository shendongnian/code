    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ assembly name="System.Web" #>
    <#@ import namespace="System.Reflection" #> 
 
    public partial class MyUserControl
    {
    <#
	PropertyInfo[] properties = typeof(System.Web.UI.WebControls.TextBox).GetProperties(
        BindingFlags.Public | BindingFlags.Instance);
    foreach (PropertyInfo property in properties)
    {
        WriteLine(string.Format("    public {0} {1}", property.PropertyType.FullName, property.Name));
        WriteLine("    {");
        if(property.GetGetMethod() != null)
        {
            WriteLine("        get { return Target." + property.Name + "; } ");
        }
        if(property.GetSetMethod() != null)
        {
            WriteLine("        set { Target." + property.Name + " = value; } ");
        }
    
        WriteLine("    }");
        WriteLine("");
    }
    #>
    }
	
