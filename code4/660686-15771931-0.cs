    @foreach (var item in Model)
    {
        <li>
            <div class="lnewsblock">
                <p class="newsthumb">
				@if(item.ShortImage != null)
				{
                    <img src="@Html.Raw(item.ShortImage)" width="90" height="71" alt="" /></p>
				}
				else
				{
					</p>
				}
                <p class="datetxt">@Html.Raw(item.Date.Value.ToString("ddd MM.dd.yyyy"))</p>
				<h2> <a href="/resources/newsdetail?id=@Html.Raw(item.ID.ToString())">@Html.Raw(item.Title)</a></h2>
				@if(item.Description.Length >= 125)
				{
					<p class="greytxt">@Html.Raw(item.Description.Left(125))<a href="/resources/newsdetail?id=@Html.Raw(item.ID.ToString())"> more</a></p>
				}
				else
				{
					<p class="greytxt">@Html.Raw(item.Description)<a href="/resources/newsdetail?id=@Html.Raw(item.ID.ToString())"> more</a></p>
				}
            </div>
        </li>
    }
