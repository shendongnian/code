        public static Category Parse(XElement value)
        {
            return new Category
            {
                Id = int.Parse(value.Attribute("id").Value),
                Name = value.Attribute("name").Value,
                Description = value.Attribute("description").Value,
                SubCategories = value.Elements().Select(e1 => Parse(value)).ToList()
            };
        }
