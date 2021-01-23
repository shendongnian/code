    @model SampleApplication.Models.BasicDemoModel
    
    <form id="AjaxForm" action="/">
        <table>
            <tr>
                <td>@Html.LabelFor(x => x.Name)</td>
                <td>
                    @Html.TextBoxFor(x => x.Name)
                    @Html.ValidationMessageFor(x => x.Name, "*")
                </td>
            </tr>
            <tr>
                <td>@Html.LabelFor(x => x.Email)</td>
                <td>
                    @Html.TextBoxFor(x => x.Email)
                    @Html.ValidationMessageFor(x => x.Email, "*")
                </td>
            </tr>
            @{
                Html.RenderPartial("Address", Model);
            }
        </table>
        @if (!string.IsNullOrWhiteSpace(Model.Message))
        {
            <h2>@Model.Message</h2>
        }
        @if (!ViewContext.ViewData.ModelState.IsValid)
        {
            @Html.ValidationSummary()
        }
        <input type="submit" title="Submit Form" onclick="PostFormWithAjax();return false;" />
    </form>
