    <#
        // Here is the model
        Model = new []
            {
                P ("string", "ClientName"),
                P ("string", "DealerID"),
            };
    #>
    <#
        // Here is the "view", this can be extracted into a ttinclude file and reused
    #>
    namespace MyNameSpace
    {
        using System.Web;
        partial class SessionState
        {
    <#
        foreach (var propertyDefinition in Model)
        {
    #>
            public static <#=propertyDefinition.Type#> <#=propertyDefinition.Name#>
            {
                get
                {
                    object obj = HttpContext.Current.Session["<#=propertyDefinition.SessionName#>"];
                    if (obj != null)
                    {
                        return (<#=propertyDefinition.Type#>)obj;
                    }
                    return null;
                }
                set
                {
                    HttpContext.Current.Session["<#=propertyDefinition.SessionName#>"] = value;
                }
            }    
    <#
        }
    #>
        }
    }
    <#+
    
        PropertyDefinition[] Model = new PropertyDefinition[0];
        class PropertyDefinition
        {
            public string Type;
            public string Name;
            public string SessionName
            {
                get
                {
                    var name = Name ?? "";
                    if (name.Length == 0)
                    {
                        return name;
                    }
                    return char.ToLower(name[0]) + name.Substring(1);
                }
            }
        }
        static PropertyDefinition P (string type, string name)
        {
            return new PropertyDefinition
            {
                Type = type ?? "<NoType>",
                Name = name ?? "<NoName>",
            };
        }
    #>
