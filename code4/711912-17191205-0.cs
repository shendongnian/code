    public interface IChannel { … }
    public class Proxy<TClient>()
        where TClient : ClientBase<IChannel>
    { 
    }
    public class MyObscureChannel : IChannel { … }
    public class MyObscureClient : ChannelBase<MyObscureChannel> { … }
    …
    var client = new Proxy<MyObscureClient>(…); // MyObscureChannel is implied here
