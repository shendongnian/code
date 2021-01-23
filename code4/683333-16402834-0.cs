    ValidationResult Validate(T t)
    {
        Type OutResultNotUsed;
        if (typeof(T).IsOrInherits(typeof(IEnumerable<>), out OutResultNotUsed))
            throw new Exeption("glkjglkjsdg");
    }
