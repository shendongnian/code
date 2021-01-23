    public class MyTreeView : TreeView
    {
        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            base.OnSelectedItemChanged(e);
            if (Items.Count == 0)
            {
                var lastObjectDeleted = e.OldValue;
                if (lastObjectDeleted != null)
                {
                    var effectiveValues = EffectiveValuesGetMethod.Invoke(this, null) as Array;
                    if (effectiveValues == null)
                        throw new InvalidOperationException();
                    bool foundEntry = false;
                    int index = 0;
                    foreach (var effectiveValueEntry in effectiveValues)
                    {
                        var value = EffectiveValueEntryValueGetMethod.Invoke(effectiveValueEntry, null);
                        if (value == lastObjectDeleted)
                        {
                            foundEntry = true;
                            break;
                        }
                        index++;
                    }
                    if (foundEntry)
                    {
                        effectiveValues.SetValue(null, index);
                    }
                }
            }
        }
        protected MethodInfo EffectiveValueEntryValueGetMethod
        {
            get
            {
                if (effectiveValueEntryValueGetMethod == null)
                {
                    var effectiveValueEntryType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.Name == "EffectiveValueEntry").FirstOrDefault();
                    if (effectiveValueEntryType == null)
                        throw new InvalidOperationException();
                    var effectiveValueEntryValuePropertyInfo = effectiveValueEntryType.GetProperty("Value", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance);
                    if (effectiveValueEntryValuePropertyInfo == null)
                        throw new InvalidOperationException();
                    effectiveValueEntryValueGetMethod = effectiveValueEntryValuePropertyInfo.GetGetMethod(nonPublic: true);
                    if (effectiveValueEntryValueGetMethod == null)
                        throw new InvalidOperationException();
                }
                return effectiveValueEntryValueGetMethod;
            }
        }
        protected MethodInfo EffectiveValuesGetMethod
        {
            get
            {
                if (effectiveValuesGetMethod == null)
                {
                    var dependencyObjectType = typeof(DependencyObject);
                    var effectiveValuesPropertyInfo = dependencyObjectType.GetProperty("EffectiveValues", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance);
                    if (effectiveValuesPropertyInfo == null)
                        throw new InvalidOperationException();
                    effectiveValuesGetMethod = effectiveValuesPropertyInfo.GetGetMethod(nonPublic: true);
                    if (effectiveValuesGetMethod == null)
                        throw new InvalidOperationException();
                }
                return effectiveValuesGetMethod;
            }
        }
        #region Private fields
        private MethodInfo effectiveValueEntryValueGetMethod;
        private MethodInfo effectiveValuesGetMethod;
        #endregion
    }
