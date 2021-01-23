    @foreach (var x in new string[] { "x", "y" ])
    {
        if (userGuid != ViewBag.x)
       {
        @:<div class="orderdetail">
        <div class="customer">
            <p class="strong">OrderID:</p> 
            <p>@item.ID</p>
            <p class="strong">Order Date:</p>
            <p>@String.Format("{0:g}", TimeZoneInfo.ConvertTime(item.DateInitialised</p>
            <p class="strong">Customer Name:</p> 
            <p>@item.WebsiteUser.Name</p>
            <p class="strong">Practice Name:</p>
            <p>@item.WebsiteUser.PracticeName</p>
            <p class="strong">Customer E-Mail:</p> 
            <p>@item.WebsiteUser.EMailAddress</p>
        </div>
        }
        <div class="detail">
            <span class="strong">Licence Key:</span><span>@item.Licence.LicenceKey</span>
            <span class="strong">Serial No:</span><span>@item.Licence.SerialNumber</span>
        </div>               
    if (userGuid != ViewBag.x && ViewBag.x != 0)
    {
        @:</div>
        <div class="clear"></div>
    }      
    PreviousOrderId = item.ID;    
    }
