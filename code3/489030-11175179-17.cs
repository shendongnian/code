    [ProgId("Cheeso.Greet")]
    [ComVisible(true)]
    [Guid("bebcfaff-d2f4-4447-ac9f-91bf63b770d8")]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class Greet : IGreet
    {
        public IDispatch onHello { get; set; }
        public String Hello(string name)
        {
            var r = FireEvent();
            return "Why, Hello, " + name + "!!!" + r;
        }
    }
