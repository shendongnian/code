    [ServiceContract]
    public interface IService
    {
        int Alias1(int param1, string param2);
    
        int Alias2(int param1);
    }
    public partial class ServiceClient : ClientBase <IService>, IService
    {
        // other stuff
        public int Alias1(int param1, string param2)
        {
           return base.Channel.Alias1(param1, param2);
        }
    
        public int Alias2(int param1)
        {
           return base.Channel.Alias2(param1);
        }
    }
