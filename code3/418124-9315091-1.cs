    public class CustomResolver : ValueResolver<CreateContainerViewModel, Container>
    {
        protected override Container ResolveCore(CreateContainerViewModel source)
        {
    
                return new Container() { ID = source.ID };  
        }
    }
