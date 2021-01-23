    @model AaronWeb.Models.Node
    <ul>
        <li>@Model.ToString()
        @if (Model.Nodes.Count > 0)
        {
            foreach (var child in Model.Nodes)
            {
                Html.RenderPartial("_GraphPartial", child);
            }
        }
        </li>
    </ul>
