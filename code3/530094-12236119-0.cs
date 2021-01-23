    private bool isNum = true;
    [PropertyTab("IsNumaric")]
    [Browsable(true)]
    [Description("TextBox only valid for numbers only"), Category("EmSoft")] 
    public bool IsNumaricTextBox {
      get { return isNum; }
      set { isNum = value; }
    }
