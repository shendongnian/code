    @using(Html.BeginForm("ListOfUsers"))
    {
        <ul>
        @for (var i = 0; i < Model.UsersOfList.Count; i++)
        {
           <li>
           @Html.TextBoxFor(m.UsersOfList[i].LoginName, new {@class="textbox_LoginInfoAndPermission"})
           @Html.ValidationMessageFor(m => m.UsersOfList[i].LoginName)
        
           @Html.TextBoxFor(m.UsersOfList[i].UserName, new {@class="textbox_LoginInfoAndPermission"})
           @Html.ValidationMessageFor(m => m.UsersOfList[i].UserName)
           </li>
        }
        </ul>
       <button type="submit">Submit changes</button>
    }
