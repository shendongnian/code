    @using System.Xml
    @using ViewModels; 
    @model ComboData
    @{
        Response.ContentType = "text/xml";
        Layout = null;
    }
    <complete>
        <option value=""><![CDATA[&nbsp;]]></option>
        @foreach (XmlNode node in Model.xdoc.DocumentElement.ChildNodes)
        {
            <option value="@(node.Attributes[0].Value)">@(node.Attributes[0].Value)</option>
        }
    </complete>
