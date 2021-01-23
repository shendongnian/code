    ViewBag.breadcrumbs = cbh.Select(i => new BreadCrumbModel() 
                                          {
                                              Id = i.Id, 
                                              Title = i.Title 
                                          });
    @{ 
        var printSeparator = false;
    }
    @foreach(BreadCrumbModel bc in ViewBag.breadcrumbs)
    {
        @if(printSeparator)
        {
            <span class="breadcrumb-separator">&nbsp;&gt;&nbsp;</span>
        }
        <span class="breadcrumb">
          @Html.ActionLink(bc.Title, "index", "forum", new { id = bc.Id });
        </span>
        @{
            printSeparator = true;
        }
    }
