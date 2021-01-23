       @if (item != null && item.Detail != null) {
         if(item.Detail.Shiped == false){
          <th id="url_button">
                 <a href = '@Url.Action("Edit", "Dispatch", new {  id=item.DetailsID })'> Edit</a>
          </th>
         }
      }
