                for (int i = 0; i < Model.Categories.Count; i++)
                {
                    <tr>
                        <td>
                            @Html.HiddenFor(modelItem => Model.Categories[i].Id)
                            @Html.HiddenFor(modelItem => Model.Categories[i].ProductCategoryId)
                            @Html.HiddenFor(modelItem => Model.Categories[i].CategoryName)                            
                            @Html.DisplayFor(modelItem => Model.Categories[i].CategoryName)                            
                        </td>
                        <td>
                            @Html.EditorFor(modelItem => Model.Categories[i].DailyPurchaseLimit)
                            @Html.HiddenFor(modelItem => Model.Categories[i].DailyPurchaseLimit)                            
                            @Html.ValidationMessageFor(modelItem => Model.Categories[i].DailyPurchaseLimit)
                        </td>
                        <td style="text-align: center">
                            @Html.EditorFor(modelItem => Model.Categories[i].IsSelected)
                            @Html.HiddenFor(modelItem => Model.Categories[i].IsSelected)                            
                        </td>
                    </tr>
                }
