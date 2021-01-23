    ViewBag.DepartmentList = docs.Select(m => new SelectListItem
            {
                Value = SqlFunctions.StringConvert((double)m.departmentID).Trim(),
                Text = m.departmentName
            })
            .Distinct(new MyComparer<SelectListItem>()).ToList();
