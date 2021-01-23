      @model IEnumerable<Blog.Domain.Model.Category>
        @{
            ViewBag.Title = "Category";
            Layout = null;
        }
        <div>
            @foreach (var item in Model)
            {
                <ul>
                    @Html.ActionLink(item.Name, "Detail". "Category", new {id = item.id)
                </ul>
            }
        </div>
    
    public ActionResult Details(int id)
            {
    
                var category = _categoryRepository.GetById(id);
                //detail CategoryView
                return PartialView(category);
            }
