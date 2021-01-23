    Days = new List<SelectListItem>
    {
        for (var i = 1; i <= 31; i++)
        {
            Days.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString()});
        }
    },
