    System.Reflection.MemberInfo info = typeof(MyClass);
    object[] attributes = info.GetCustomAttributes(true);
    for (int i = 0; i < attributes.Length; i++)
    {
      if (attributes[i] is TemplatePart || attributes[i] is TemplateVisualState)
      {
         System.Console.WriteLine(((TemplateVisualState) attributes[i]).Name);
      }   
    }
