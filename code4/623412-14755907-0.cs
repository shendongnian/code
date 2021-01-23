    @model IList<myProject.Models.SomeData>
    
    @{
        var Information = Model;
    }
    @for (int i = 0; i < Information.Count(); i++)
    {
        <tr>
            <td>
                @Html.EditorFor(modelItem => Information[i].Description)
            </td>
        </tr>
     }
