    @model MyViewModel
    
    <table>
        <thead>
            <tr>
                <th></th>
                @foreach (var product in Model.Products)
                {
                    <th>@product.Name</th>
                }
            </tr>
        </thead>
        <tbody>
            @foreach (var partner in Model.PartnerProductPrices)
            {
                <tr>
                    <td>@partner.PartnerName</td>
                    @foreach (var price in partner.Prices)
    	            {
                        <td>
                            @if (price != null)
                            {
                                @price.Cost
                            }
                            else
                            {
                                // There was no price found matching this 
                                // product and partner => we display an empty cell
                                @:&nbsp;    
                            }
                        </td>
    	            }
                </tr>
            }
        </tbody>
    </table>
