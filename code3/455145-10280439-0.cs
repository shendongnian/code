    filters = filterItems
              .AsQueryable()
              .Select(z => new {
                    Item = z,
                    FilterType = GetFilterType(Convert.ToString(z.TemplateID))
              })
              .Select(z => new Person()
                {
                    Name = z.Item.Name,
                    ID = Convert.ToString(z.Item.ID),
                    FilterType = z.FilterType,
                    FilterMembers = GetPeronMemberDTO(Convert.ToString(z.Item.ID), searchParamDTO, z.FilterType),
                })
