    public string EntityClassOpening(EntityType entity)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1}partial class {2}{3}",
            Accessibility.ForType(entity),
            _code.SpaceAfter(_code.AbstractOption(entity)),
            _code.Escape(entity),
            _code.StringBefore(" : ", string.IsNullOrEmpty(_typeMapper.GetTypeName(entity.BaseType)) ? "BaseModel" : _typeMapper.GetTypeName(entity.BaseType)));
    }
