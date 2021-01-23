    @{if (myClient.Type!="Primary")
         {
              @Html.ActionLink("Delete", "Delete","ClientBackground", new { id=item.ID },null)
         }
     }
