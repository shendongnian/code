    [DefaultEvent("OnItemsChanged"), DefaultProperty("Items")]
    [ContentProperty("Items")]
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(FrameworkElement))]
    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)] // cannot be read & localized as string 
    public class ItemsControl : Control, IAddChild, IGeneratorHost 
    {
