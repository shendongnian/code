    @model PersonModel
    
    @using (var modal = Html.Bootstrap().Begin(new Modal().Id("modal-person").Closeable()))
    {
        @modal.Header("Edit Person")
        using (var f = Html.Bootstrap.Begin(new Form()))
        {
            using (modal.BeginBody())
            {
                @Html.HiddenFor(x => x.Id)
                @f.ControlGroup().TextBoxFor(x => x.Name)
                @f.ControlGroup().TextBoxFor(x => x.Age)
            }
            using (modal.BeginFooter())
            {
                @:@Html.Bootstrap().Button().Text("Save").Id("btn-person-submit")
                @Html.Bootstrap().Button().Text("Close").Data(new { dismiss = "modal" })
            }
        }
    }
