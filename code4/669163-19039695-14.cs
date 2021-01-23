    @model PersonModel
    @{
        // get modal helper
        var modal = Html.Bootstrap().Misc().GetBuilderFor(new Modal());
    }
    
    @modal.Header("Edit Person")
    @using (var f = Html.Bootstrap.Begin(new Form()))
    {
        using (modal.BeginBody())
        {
            @Html.HiddenFor(x => x.Id)
            @f.ControlGroup().TextBoxFor(x => x.Name)
            @f.ControlGroup().TextBoxFor(x => x.Age)
        }
        using (modal.BeginFooter())
        {
            // if needed, add here @Html.Bootstrap().ValidationSummary()
            @:@Html.Bootstrap().Button().Text("Save").Id("btn-person-submit")
            @Html.Bootstrap().Button().Text("Close").Data(new { dismiss = "modal" })
        }
    }
