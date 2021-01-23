    @model IEnumerable<Puthencruz.Rotary.Club.Models.ResourceItems>
    <ul id="res">
        @foreach(var item in Model)
        {
            <li>
                @Html.ActionLink(
                    item.Res_NA, 
                    "ResourceDetails", 
                    "Resources", 
                    new { id = item.Id }, 
                    new { @class = "detail" }
                )
            </li>
        }
    </ul>
    
    <div id="rescontent">
    
    </div>
