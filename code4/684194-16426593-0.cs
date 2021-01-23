    @if(Model != null && Model.TagsList != null) //NUll check for Model
        {
           foreach (string tag in Model.TagsList)
           {
              <li>@tag</li>
           }
        } 
