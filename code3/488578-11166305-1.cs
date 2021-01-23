    @using System.Xml.XPath
    @using umbraco.MacroEngines
    @inherits DynamicNodeContext
    @try
    {
        var baseNode = Model.AncestorOrSelf();
    
        XPathNodeIterator iterator = umbraco.library.GetPreValues(1094);
        iterator.MoveNext(); //move to first
        XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");
    
        @preValues.Count
    
        <ul>
        @while (preValues.MoveNext())
        {
            string preValue = preValues.Current.Value;
        
            <li><a href="@baseNode.Url?category=@preValue">@preValue</a></li>                      
        }
        </ul>
    }
    catch (Exception e)
    {
        @e.ToString()   
    }
