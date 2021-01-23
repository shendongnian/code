    @for (var i = 0; i < Model.SalesLines.Count; i++)
    {
        <tr>
            <td>
                @sales.ItemName
                @Html.HiddenFor(m => m.SalesLines[i].QuoteLineId)
                @Html.HiddenFor(m => m.SalesLines[i].ItemName) //assuming you want this
            </td>
            <td>
                @Html.DropDownListFor(m => m.SalesLines[i].LostReasonId, 
               ((IEnumerable<myApp.Models.LostReason>)ViewBag.LostReasons)
                   .Select(option => new SelectListItem
                   {
                       Text = (option == null ? "None" : option.LostReason),
                       Value = option.LostReasonId.ToString(),
                       Selected = (Model != null) 
                          && (option.LostReasonId == m.SalesLines[i].LostStatusId)
               }))
           </td>
       </tr>
    }
