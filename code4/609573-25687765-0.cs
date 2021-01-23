    <ul class="menu">
    	<li>
    		@Html.ActionLink("Home", "Index", "Home")
    	</li>
    	@if (System.Web.Security.Roles.IsUserInRole(User.Identity.Name, "Administrator"))
    	{
    		<li>
    			@Html.ActionLink("Statistics", "Index", "Stats")
    		</li>
    	}
    </ul>
