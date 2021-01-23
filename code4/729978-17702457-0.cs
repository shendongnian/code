    <tbody>
                @foreach (PCNWeb.Models.Switch item in Model)
                {
                    /*System.Reflection.PropertyInfo[]*/ properties = item.GetType().GetProperties();
                    <tr>
                    @foreach (var property in properties)
                    {                    
                        <td>
                            property.Name
                        </td>
                    }
                    </tr>
    
                }
            </tbody>
