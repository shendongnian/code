    enum SameName { Value }
    class Tester
    {
       void Method1() {
          SameName sameName;
          SameName test = SameName.Value;
       }
       void Method2() {
          string sameName;
          SameName test = SameName.Value;
       }
    }
