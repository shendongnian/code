        Dim People As New List(Of Person) From {New Person With {.Name = "Richard", .ID = 1}}
        Dim sl = People.ToSelectList(Function(p) p.Name,
                                     Function(p) p.ID,
                                     Function(p) p.ID = 1,
                                     {New SelectListItem With {.Value = 0,
                                                               .Text = "Please Select A Person"}})
