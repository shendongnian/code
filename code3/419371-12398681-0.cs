    private readonly Doodad _oldField;
    [OptionalField(VersionAdded = 2)]
    private readonly Widget _newField;
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        if (_oldField != null && _newField == null)
        {
            var field = GetType().GetField("_newField",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.DeclaredOnly |
                System.Reflection.BindingFlags.NonPublic);
            field.SetValue(this, new Widget(_oldField));
        }
    }
