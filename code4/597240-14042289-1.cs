    @model System.Web.Security.MembershipUserCollection
    <h2>Users</h2>
    <ul>
        @foreach(var u in Model)
        {
            <li>u.UserName</li>
        }
    </ul>
