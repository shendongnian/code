    @model Books.Web.Models.ItemSource
    @{
    	ViewBag.OGTitle = Model.Item.Title;
    	ViewBag.OGDesc = Model.Item.Description;
    	ViewBag.OGUrl = Request.Url.AbsoluteUri;
    	ViewBag.OGImage = Request.Url.Scheme + "://" + Request.Url.Host + Url.Action("ItemCover", "Image", new { id = Model.Item.Id, height = 350 });
    	Layout = "~/Views/Shared/Layout.cshtml";
    }
    <div>Page content here</div>
