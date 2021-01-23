    <div style="position:absolute; left:300px; top:633px;">
    @using (Html.BeginForm("Delete", null, new { id = Model.BicycleSellerListingId }, FormMethod.Post))
    {
       if(Model.BicycleSellerListingId < 0){
           <button type="submit">Delete Listing</button>
       }
    }
    </div>
