    @model NotificationDeliveryType
    
    <tr>
        <td>
            @foreach (NotificationDeliveryType item in Enum.GetValues(typeof(NotificationDeliveryType)))
            {
                <label for="@ViewData.TemplateInfo.GetFullHtmlFieldId(item.ToString())">@item</label>
                <input type="checkbox" id="@ViewData.TemplateInfo.GetFullHtmlFieldId(item.ToString())" name="@(ViewData.TemplateInfo.GetFullHtmlFieldName(""))" value="@item" @Html.Raw((Model & item) == item ? "checked=\"checked\"" : "") />
            }
        </td>
    </tr>
