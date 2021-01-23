    public static void ExtensionMethod<T>(this IEnumerable<T> list,
                                          IEnumerable<T> anOtherlist)
    {
        bool listItselfNotNull = list != null;
        bool anOtherListNotNull = anOtherList != null;
    }
