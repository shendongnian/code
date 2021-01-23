    @{
    var items = new[]
                    {
                        new Test {Id = 1, Name = "Jhon"}, 
                        new Test {Id = 2, Name = "Scott"}
                    };
                    
    var selectList = new SelectList(items, "Id", "Name", 2);
    var selectEnumerable = items.Select(x => new SelectListItem
                                                 {
                                                     Selected = x.Id == 2,
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 });
    }
    @Html.DropDownList("name", selectList)
    @Html.DropDownList("name2", selectEnumerable)
