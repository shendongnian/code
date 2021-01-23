    @{
        int PreviousOrderId = 0;
    }
    
    
    @foreach (var item in Model) {
    
    <div class="orderdetail">
    
    
    @if (item.ID != PreviousOrderId){
    
        <div class="customer">
            <p class="strong">OrderID:</p> 
            <p>@item.ID</p>
            <p class="strong">Order Date:</p>
            <p>@String.Format("{0:g}", TimeZoneInfo.ConvertTime(item.DateInitialised, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time")))</p>
            <p class="strong">Customer Name:</p> 
            <p>@item.WebsiteUser.Name</p>
            <p class="strong">Practice Name:</p>
            <p>@item.WebsiteUser.PracticeName</p>
            <p class="strong">Customer E-Mail:</p> 
            <p>@item.WebsiteUser.EMailAddress</p>
        </div>
       }
    
    
        <div class="detail">
            <span class="strong">Licence Key:</span><span><div style="width:140px; overflow:auto;">@item.Licence.LicenceKey</div></span>
            <span class="strong">Serial No:</span><span>@item.Licence.SerialNumber</span>
        </div>               
    
        <div class="clear"></div>
    </div>
    
       PreviousOrderId = item.ID;
    
    
    }
