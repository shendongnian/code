      TypeBuilder myClass =
         myModule.DefineType("MyClass", TypeAttributes.Public);
      MethodBuilder onPropertyNameChanged= myClass.DefineMethod("OnPropertyNameChanged",
         MethodAttributes.Public, typeof(void), new Type[]{typeof(Object)});
      ILGenerator onPropertyNameChangedIl= onPropertyNameChanged.GetILGenerator();
      onPropertyNameChangedIl.Emit(OpCodes.Ret);
      // Create the event.
      EventBuilder propertyNameChanged= myClass.DefineEvent("PropertyNameChanged", EventAttributes.None,
         typeof(PropertyChangedHandler)); //should be declared before
      propertyNameChanged.SetRaiseMethod(onPropertyNameChanged);
      myClass.CreateType();
