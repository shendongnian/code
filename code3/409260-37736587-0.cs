        this.ddlBlah.DataSource =
          Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>()
          .ToDictionary(x => x, x => x.ToDisplayText());
        this.ddlBlahs.DataValueField = "key";
        this.ddlBlah.DataTextField = "value";
        this.ddlBlah.DataBind();
    public static string ToDisplayText(this Enum Value)
    {
      try
      {
        Type type = Value.GetType();
        MemberInfo[] memInfo = type.GetMember(Value.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
          object[] attrs = memInfo[0].GetCustomAttributes(
                                        typeof(DisplayText),
                                        false);
          if (attrs != null && attrs.Length > 0)
            return ((DisplayText)attrs[0]).DisplayedText;
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Your favorite error handling here");
      }
      return Value.ToString();
      // End of ToDisplayText()
    }
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class DisplayText : System.Attribute
    {
      public string DisplayedText;
      public DisplayText(string displayText)
      {
        DisplayedText = displayText;
      }
      // End of DisplayText class definition
    }
