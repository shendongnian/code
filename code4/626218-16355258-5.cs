    @foreach (var api in Model)
    {
        if (api.ActionDescriptor.ControllerDescriptor.ControllerType.Namespace != null)
        {
            var versionName = api.ActionDescriptor.ControllerDescriptor.ControllerType.Namespace.Replace(".Controllers", "").Split('.').Last();
            api.RelativePath = api.RelativePath.Replace("v???", versionName);
        }
        <tr>
            <td class="api-name"><a href="@Url.Action("Api", "Help", new { apiId = api.GetFriendlyId() })">@api.HttpMethod.Method @api.RelativePath</a></td>
            <td class="api-documentation">
            @if (api.Documentation != null)
            {
                <p>@api.Documentation</p>
            }
            else
            {
                <p>No documentation available.</p>
            }
            </td>
        </tr>
    }
