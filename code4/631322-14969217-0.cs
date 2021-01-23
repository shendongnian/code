    @if (Request.IsAuthenticated && User.IsInRole("Administrators")
    {
         <div id="sidebar">
            <div class="module">
            <ul class="menu">
                                <li>@Html.ActionLink("Home", "Index", "Home")</li>
                                <li>@Html.ActionLink("About", "About", "Home")</li>
                                <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                            </ul>
             </div>
             <div class="mainContent">
                 Hello, @User.Identity.Name !
             </div>
         </div>
    }
