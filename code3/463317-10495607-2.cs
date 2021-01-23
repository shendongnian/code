    interface ISecondDeep {
      Boolean SomethingToDo(String str);
    }
    class SecondDeep : ISecondDeep { ... }
    class FirstDeep {
      readonly ISecondDeep secondDeep;
      public FirstDeep(ISecondDeep secondDeep) {
        this.secondDeep = secondDeep;
      }
      public String AddA(String str) {   
        var flag = this.secondDeep.SomethingToDo(str);
        ...
      }
    }
