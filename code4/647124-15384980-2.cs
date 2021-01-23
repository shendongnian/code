    @using System.ComponentModel
    @using System.Reflection
    @using System.Linq;
    @model object
    
    @{
        var model = Html.ViewData.Model;
        if (model == null)
        {
            throw new ArgumentException("You must have a model in order to use this template");
        }
        var enumType = model.GetType();
        if (!enumType.IsEnum)
        {
            throw new ArgumentException("This method works only with enum types.");
        }
    
        var fields = enumType.GetFields(
            BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public
        );
        var values = Enum.GetValues(enumType).OfType<object>();
        var items =
            from value in values
            from field in fields
            let descriptionAttribute = field
                .GetCustomAttributes(
                    typeof(DescriptionAttribute), true
                )
                .OfType<DescriptionAttribute>()
                .FirstOrDefault()
            let description = (descriptionAttribute != null)
                ? descriptionAttribute.Description
                : value.ToString()
            where value.ToString() == field.Name
            select new { Id = value, Name = description };
    
        var selectList = new SelectList(items, "Id", "Name", model);
    }
    
    @Html.DropDownList("", selectList)
