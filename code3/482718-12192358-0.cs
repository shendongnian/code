    public string EntityClassOpening(EntityType entity)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1}partial class {2}{3} : {4}",
            Accessibility.ForType(entity),
            _code.SpaceAfter(_code.AbstractOption(entity)),
            _code.Escape(entity),
            _code.StringBefore(" : ", _typeMapper.GetTypeName(entity.BaseType)),
			"INotifyPropertyChanged");
    }
    public string Property(EdmProperty edmProperty)
    {
		return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1} {2} {{ {3}{6} {4}{5} }}",
            Accessibility.ForProperty(edmProperty),
            _typeMapper.GetTypeName(edmProperty.TypeUsage),
            _code.Escape(edmProperty),
            _code.SpaceAfter(Accessibility.ForGetter(edmProperty)),
            _code.SpaceAfter(Accessibility.ForSetter(edmProperty)),
			"set { _"+_code.Escape(edmProperty).ToLower()+" = value; OnPropertyChanged(\""+_code.Escape(edmProperty)+"\");}",
			"get { return _"+_code.Escape(edmProperty).ToLower()+"; }");
		      
    }
	public string Private(EdmProperty edmProperty) {
		return string.Format(
			CultureInfo.InvariantCulture,
			"{0} {1} _{2};",
			"private",
			_typeMapper.GetTypeName(edmProperty.TypeUsage),
			_code.Escape(edmProperty).ToLower());
		
	}
