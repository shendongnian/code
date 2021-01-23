    @model List<RowViewModel>
    @using (Html.BeginForm())
    {
        <table>
            @for (var i = 0; i < Model.Count; i++)
            {
                <tr>
                    @for (var j = 0; j < Model[i].Columns.Count; j++)
                    {
                        <td>
                            @Html.HiddenFor(x => x[i].Columns[j].RowNumber)
                            @Html.HiddenFor(x => x[i].Columns[j].ColumnNumber)
                            @Html.DisplayFor(x => x[i].Columns[j].QuestionText)
                            @Html.EditorFor(x => x[i].Columns[j].FieldValue)
                        </td>
                    }
                </tr>
            }
        </table>
        <button type="submit">Save</button>
    }
