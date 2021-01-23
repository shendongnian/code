        private void FillAvailableValues(ValueModel modelValue, Entities db)
		{
			var values = (from v in db.Values
						   orderby v.Name
						   select v);
            foreach (var model in modelValue.Values)
			{
				model.AvailableDropDown = new List<SelectListItem>();
				model.AvailableDropDown.Add(new SelectListItem()
				{
					Text = "Unassigned",
					Value = "0",
					Selected = (model.Id == 0)
				});
				foreach (var value in values)
				{
					model.AvailableDropDown.Add(new SelectListItem()
					{
						Text = value.Name,
						Value = value.Id,
						Selected = (model.Id.ToString() == colour.Id)
					});
				}
			}
		}
        private void InitDefaultDropDown(ValueModel model)
        {
            model.DropDown = new List<ValueDropDownModel>();
            for (int i = 0; i < 15; i++)
            {
                model.DropDown.Add(new ValueDropDownModel()
                {
                    DropDown = i + 1,
                    Id = 0
                });
            }
        }
