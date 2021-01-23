    // if GetCheckedStatus() returns bool:
    object IsCheckedAsObj = GetCheckedStatus();
    if (IsCheckedAsObj == null)
        throw new InvalidOperationException("Status not found");
    bool _HasParsed = (bool)IsCheckedAsObj;
    // if GetCheckedStatus() returns bool? (again: Nullable<bool>):
    object IsCheckedAsObj = GetCheckedStatus();
    if (!((bool?)IsCheckedAsObj).HasValue())
        throw new InvalidOperationException("Status not found");
    bool _HasParsed = ((bool)IsCheckedAsObj);
