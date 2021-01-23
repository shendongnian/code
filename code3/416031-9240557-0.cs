                <ul id="menu">
                        <li>@Html.ActionLink("Home", "Index", "Home")</li>
                        @if (!User.Identity.IsAuthenticated)
                        {
                             <li>@Html.ActionLink("SignUp", "SignUp", "Home")</li>
                        }
                </ul>
