    @model CottagesOfHope.ViewModels.AttendanceViewModel
    @{
       ViewBag.Title = "Attendance";
     }
    <h2>Mark Attendance</h2>
    @using (Html.BeginForm())
    {
    <fieldset>
        <legend>Attendance</legend>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Attendance</th>
                </tr>
            </thead>
            <tbody>
                @for (int i = 0; i < Model.Attending.Count(); i++)
                {
                    <tr>
                           <td>@Model.Attending[i].User.FirstName 
                               @Model.Attending[i].User.LastName</td>
                           <td>@Html.CheckBoxFor(model => Model.Attending[i].Attended)</td>
                            @Html.HiddenFor(model => Model.Attending[i].AttendID)
                       </tr>
                }
            </tbody>
        </table>
        <p>
            <input type="submit" value="Submit" />
        </p>
    </fieldset>
    }
