    @using MyModel.MyTools.Orders.SumOrder
    @model SumOrder
    @{
        ViewBag.Title = "View Invoice";
    }
    <h2>View Invoice</h2>
    @{
        int i = 0;
    }
    <table>
        @foreach(var mod in Model.OCI)
        {
            var modCount = @mod.Product.Count();
            <tr>
                <th>@mod.ClientLocation</th>
            </tr>
            <tr>
                <th>Product</th>
                <th>Price</th>
            </tr>
            foreach (var items in mod.Product)
            {
                <tr>
                    <td>
                        @mod.Product.ElementAtOrDefault(i)
                    </td>
                    <td>
                        @mod.Price.ElementAtOrDefault(i)
                    </td>
                </tr>
                i++;
            }
        }
    </table>    
