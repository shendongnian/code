    var expected = new[] {
      new { 
              PilotName = "Higgins", 
              Planes = (IEnumerable)null
          },
      new {
              PilotName = "Higgins", 
              Planes = (IEnumerable)new [] {
                                  new { PlaneName = "B-52" },
                                  new { PlaneName = "F-14" } 
                              }
          }
    };
