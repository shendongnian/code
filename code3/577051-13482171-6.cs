    public string NavigationProperty(NavigationProperty navigationProperty)
    {
        var endType = _typeMapper.GetTypeName(navigationProperty.ToEndMember.GetEntityType());
		
        return string.Format(
			CultureInfo.InvariantCulture,
			"{0}\n\n    {1}  {2}  {3}\n    {{\n      {4}get\n        {{\n           return _{3}; \n        }}\n        {5} set\n        {{\n          _{3}=value; OnSet{3}();\n        }}\n      }}\n\n    {6}",
			string.Format(CultureInfo.InvariantCulture, "{0} _{1};",_typeMapper.GetTypeName(navigationProperty.TypeUsage), _code.Escape(navigationProperty)),
			AccessibilityAndVirtual(Accessibility.ForProperty(navigationProperty)),
            navigationProperty.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many ? ("ICollection<" + endType + ">") : endType,
            _code.Escape(navigationProperty),
            _code.SpaceAfter(Accessibility.ForGetter(navigationProperty)),
            _code.SpaceAfter(Accessibility.ForSetter(navigationProperty)),
			string.Format(CultureInfo.InvariantCulture, "partial void OnSet{0}();", _code.Escape(navigationProperty)));
    }
