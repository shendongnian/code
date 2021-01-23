    /// /Views/Helpers/AndiEditorForExtensions.cshtml
    @helper AndiEditorFor(HtmlHelper html, Website.Areas.Admin.EditableContent model) {
        @if (!string.IsNullOrWhiteSpace(Model.EditorView))
        {
        <text>
            @Model.EditorView
            @Html.EditorForModel(Model.EditorView)
        </text>
        }
        else
        {
          //Original template
        }
    }
