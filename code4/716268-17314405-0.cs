    @string[] usersInRole = Roles.GetUsersInRole("RegularUser");
	<ul>
	@foreach (var item in Model)
	{
		if(usersInRole.Contains(item.Firstname))
		{
			<li>
				<h3>@Html.DisplayFor(model => item.FullName)</h3>
				@if (item.Image != null)
				{
					<img src="@Url.Content(item.Image)" alt="" />
				}
				else
				{
					<br />
				}
			</li>
		}
	}
	</ul>
