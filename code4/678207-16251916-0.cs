    String dog1Legs;
    String dog2Legs;
    String dog3Legs;
    for (int i=1; i<4; i++)
    {
        FieldInfo z = this.GetType().GetField("dog" + i + "Legs");
        object p = (object)this;     
        z.SetValue(p, "test");
    }
