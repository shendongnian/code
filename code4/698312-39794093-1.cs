    public string EntityClassOpening(EntityType entity)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0} " + Environment.NewLine + " {1} {2} partial class {3}{4}", 
    		"[Serializable]", 
            Accessibility.ForType(entity),
            _code.SpaceAfter(_code.AbstractOption(entity)),
            _code.Escape(entity),
            _code.StringBefore(" : ", _typeMapper.GetTypeName(entity.BaseType)));
    }
Save your .tt file and your entity class files get [Serializable] Attribute on them.
