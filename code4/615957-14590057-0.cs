        @model System.Collections.Specialized.OrderedDictionary
        (...)
        @{int counter = 0;}
        @{string name = "";}
        @foreach (DictionaryEntry attribute in Model)
        {
            { name = "[" + counter + "].key"; }
            @Html.Hidden(name, attribute.Key)
            {name = "[" + counter + "].value";}
            @attribute.Key @Html.TextBox(name, attribute.Value)
            counter++;
            <br />
        }
