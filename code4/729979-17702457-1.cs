    <tbody>
                @foreach (PCNWeb.Models.Switch item in Model)
                {
                    /*System.Reflection.PropertyInfo[]*/ properties = item.GetType().GetProperties();
                    <tr>
                    @foreach (var property in properties)
                    {                    
                        <td>
                            @property.GetValue(item,null)
                        </td>
                    }
                    </tr>
    
                }
            </tbody>
