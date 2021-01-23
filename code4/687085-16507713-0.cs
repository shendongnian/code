public static class Dal
{
    public static Record Query(Operation operation, Parameters parameters);
}
var result = Dal.Query(Operation.DoSomething, new DoSomethingParameters {...});
