    <div class="list-container">
        <ul>
          @{
            int i = 0;   
            foreach (var item in Model.Items)
            {
              if (i%8 == 0)
              {
                <li>@item.ContentItem.Title.Value</li>
              }
              i++; 
            } 
          }
        </ul>
      </div>
