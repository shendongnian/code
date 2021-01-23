    var kernel = your fully configured kernel;
    var bindingsField = typeof(KernelBase).GetField("bindings", BindingFlags.NonPublic | BindingFlags.Instance);
    var bindings = bindingsField.GetValue(kernel) as IEnumerable<KeyValuePair<Type, ICollection<IBinding>>>;
    foreach (var bindingsEntry in bindings
        .Where(bindingsEntry => bindingsEntry.Value
            .Any(binding => binding.BindingConfiguration.ProviderCallback == null)))
    {
        throw new Exception(string.Format("No Provider callback defined for {0}.", bindingsEntry.Key));
    }
