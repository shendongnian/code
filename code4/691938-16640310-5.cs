    @using ISApplication.Models
    @model IEnumerable<PersonInformation>
    @
    {
      List<PersonalInformation> people = Model.ToList();
    }
    @for(int i = 0; i < people.Count; i++)
    {
        @Html.LabelFor(m => people[i].Name) // Error here.
        @Html.DisplayFor(m => people[i].Name) // But this line is ok
       
        @* and so on... *@
    }
