internal static class ElementParser&lt;T&gt;
{
  public static Func&lt;XElement, string, T&gt; Convert = InitConvert;
  T DefaultConvert(XElement element, string attribute)
  {
    return Default(T); // Or maybe throw exception, or whatever
  }
  T InitConvert(XElement element, string attribute)
  {
    if (ElementParser&lt;int&gt;.Convert == ElementParser&lt;int&gt;.InitConvert)
    {  // First time here for any type at all
      Convert = DefaultConvert; // May overwrite this assignment below
      ElementParser&lt;int&gt;.Convert =
        (XElement element, string attribute) =>
          Int32.Parse(element.Attribute(attribute).Value);
      ElementParser&lt;double&gt;.Convert =
        (XElement element, string attribute) =>
          Int32.Parse(element.Attribute(attribute).Value);
      // etc. for other types
    }
    else // We've done other types, but not this type, and we don't do anything nice for it
    {
      Convert = DefaultConvert;
    }
    return Convert(element, attribute);      
  }
}
public static T ParseAttributeValue<T>(this XElement element, string attribute)
{
  ElementParser&lt;T&gt;.Convert(element, attribute);
}
