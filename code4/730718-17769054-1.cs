    @using System.Data;
    @model DataTable
    <table>
    @{DataRow rowHead = Model.Rows[0];
        <thead>
            <tr>
                @foreach (DataColumn colHead in Model.Columns)       
                {
                    <th>@rowHead[colHead.ColumnName]</th> 
                 }
            </tr> 
        </thead>
    }
        <tbody>
            @{int rowCount = 1;}
            @foreach (DataRow row in Model.Rows)
                {
                    <tr>
                        @foreach (DataColumn col in Model.Columns)
                        {
                            <td>@row[col.ColumnName]</td> 
                         }
                    </tr>
                   rowCount = rowCount + 1;
                } 
        </tbody>
    </table>
