    using System.Linq;
    foreach (var checkBox in Checksum_Collection.Children
        .OfType<CheckBox>()
        .Where(cb => (bool)cb.IsChecked))
    {
        var name = checkBox.Name;
        Trace.TraceInformation("{0} is checked", name);
    }
