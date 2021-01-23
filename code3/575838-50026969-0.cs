    public MyClass Clone()
    {
      MyClass MyClassObj =new MyClass();
      MyClassObj.Property1 = this.Property1;
      .
      .
      MyClassObj.Property_N = this.Property_N;
      return MyClass;
    }
