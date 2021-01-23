    public IEnumerable<Ability> GetAbilitiesForClasses(string[] asClassNames, int iLevel)
    {
        return Classes
               .Where(X => asClassNames.Contains(X.Name))
               .SelectMany(X => X.Abilities)
               .Where(X => X.Level <= iLevel)
               .ToList();
    }
