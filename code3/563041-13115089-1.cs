    @model PlayMvc.Models.DiagnosticCollection<string>
    @{System.Diagnostics.Debug.Print("Before foreach");}
    @foreach (var item in Model)
    {
        System.Diagnostics.Debug.Print("After foreach");
        @item
    }
