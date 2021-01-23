    @model System.Data.DataTable
    @using System.Data;
..................
..............
........
  
     <table class="table table-hover">
                            <thead>
                                <tr>
                                    @foreach (DataColumn col in Model.Columns)
                                    {
                                        <th>@col.ColumnName</th>
                                    }
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (DataRow row in Model.Rows)
                                {
                                    <tr>
                                        @foreach (DataColumn col in Model.Columns)
                                        {
                                            <td>@row[col.ColumnName]</td>
                                        }
                                    </tr>
                                }
                            </tbody>
                        </table>
