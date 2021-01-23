    class MyStringElement : StringElement {
      public MyStringElement (string caption, string hiddenValue) : base (caption) {
          HiddenValue = hiddenValue;
      }
      public string HiddenValue { get; set; }
    }
