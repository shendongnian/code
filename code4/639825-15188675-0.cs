    public static bool IsNullOrEmpty([ValidatedNotNullAttribute] this string target)
    {
        return string.IsNullOrEmpty(target);
    }
    //The naming is important to inform FxCop
    sealed class ValidatedNotNullAttribute : Attribute { }
