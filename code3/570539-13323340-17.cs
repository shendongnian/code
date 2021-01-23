    public class SomeMethodHandler 
        : IMethodHandler<SomeMethodParameters>
    {
        void Handle(SomeMethodParameters parameter)
        {
            parameter.Result = SomeClass.SomeMethod(
                parameter.id,
                parameter.Name, 
                parameter.Color, 
                parameter.Quantity);
        }
    }
