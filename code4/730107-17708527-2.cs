    <p>
      <%: Html.Label("Type") %>
      <%: Html.Telerik().DropDownList().Name("Type")
        .HtmlAttributes(new { id = "type" })
        .Items(items => {
            items.Add().Text("").Value("");
            items.Add().Text("Numbers").Value("1");
            items.Add().Text("Alphabets").Value("2");
        })
        .CascadeTo("Values")
      %>    
    </p>
    <p>
      <%: Html.Label("Values" %>
      <%: Html.Telerik().DropDownList().Name("Values")
        .HtmlAttributes(new { id = "values" }) 
        .DataBinding(b => b.Ajax().Select("GetDropDownValues", "Home"))
      %>       
    </p>
