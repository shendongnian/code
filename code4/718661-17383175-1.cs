      public enum TestEnum {
        None,
        One,
        Two,
        Three
      }
    
      [Flags]
      public enum TestOptions {
        None = 0,
        One = 1,
        Two = 2,
        Three = 4
      }
    
      ...
    
      // Let them be in German (for demonstration only)... 
      TestEnum.None.RegisterDisplayName("Nichts");
      TestEnum.One.RegisterDisplayName("Eins");
      TestEnum.Two.RegisterDisplayName("Zwei");
      TestEnum.Three.RegisterDisplayName("Drei");
    
      // Usually, you obtain display names from resources:
      // TestEnum.None.RegisterDisplayName(Resources.NoneName);
      // ...
    
      TestOptions.None.RegisterDisplayName("-");
      TestOptions.One.RegisterDisplayName("bit 0 set");
      TestOptions.Two.RegisterDisplayName("bit 1 set");
      TestOptions.Three.RegisterDisplayName("bit 2 set");
      TestOptions.Four.RegisterDisplayName("bit 3 set");
    
      ...
    
      TestEnum v = TestEnum.Two;
      String result = v.AsDisplayName(); // <- "Zwei"
    
      TestOptions o = TestOptions.One | TestOptions.Three | TestOptions.Four;
      String result2 = o.AsDisplayName(); // <- "[bit 0 set, bit 2 set, bit 3 set]"
