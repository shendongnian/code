    The view you will need 
    @model IEnumerable<Product>
    <div>
    @{
      var grid = new WebGrid(Model, defaultSort:"Price");
    }
    @grid.GetHtml()
    </div>
