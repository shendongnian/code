    private void someMethod() {
        var genericSave = repository // This can be done during initialization
            .GetType()
            .GetMethods()
            .Where(m => m.Name == "Save" && m.IsGenericMethodDefinition);
        var t = MyCollectionViewSource.CurrentItem.GetType();
        genericSave
            .MakeGenericMethod(new[] {t})
            .Invoke(new object[] {MyCollectionViewSource.CurrentItem});
    }
