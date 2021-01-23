    @using System;
    @model TheManhattanProject.Models.CellValueViewModel
    <td>
    @{if(Model.Value.StartsWith("<input type='checkbox'"))
    {
        @Html.Raw(Model.Value);
    }
    else
    {
        @Html.DisplayFor(x => x.Value);
    }
    }
    </td>
