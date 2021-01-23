      // iterate the DtoSelection Enum
      foreach(var e in Enum.GetValues(DtoSelection))
      {
        DtoSelection dtoSel = (DtoSelection)e;
        int n = (int)dtoSel;
        Container.Register<AbstractDto>("Dto" + n, dtoSel.ToString());
      }
