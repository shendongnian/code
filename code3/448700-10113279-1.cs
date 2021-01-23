    @model IEnumerable<DarkRobot.Models.Post>
    <p>
    @Html.ActionLink("Create New", "Create")
    </p>
            <aside class="blogAside">
				<h3>history of words</h3>
                <ul class="linkList">
                @foreach (var item in Model.Reverse())
                {
                    string name = item.Title;
                    <li><a>@Html.ActionLink(name, "Details", new { id = item.Id }, null)</a></li>
                }
                </ul>
			</aside>
