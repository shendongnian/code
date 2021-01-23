    @if (Request.IsAuthenticated && HttpContext.Current.User.IsInRole("Interviewer"))
                    {
                        <script type="text/javascript">
                            $("#logindisplay").show();
                        </script>
                        <li>@Html.ActionLink("Forside", "Index", "Home")</li>
                        <li>@Html.ActionLink("Spørgeskema", "Index", "Survey2")</li>
                        <li>@Html.ActionLink("Brugere", "Index", "UserAdministration")</li>
                        <li>@Html.ActionLink("Statistik", "Index", "Statistik")</li>
                        <li>@Html.ActionLink("Vagtplan", "Vagtplan", "Statistik")</li>
                    }
    @if (HttpContext.Current.User.IsInRole("Respondent"))
                        {
                             <li>@Html.ActionLink("Gammelt spørgeskema", "Index")</li>
                        }
