    //.h
    [Windows::Foundation::Metadata::WebHostHidden]
    public interface class ICallback
    {
    public:
        virtual void Exec( Platform::String ^Command, Platform::String ^Param);
    };
    //.cpp
    ICallback ^CSCallback = nullptr;
    void Direct3DInterop::SetCallback( ICallback ^Callback)
    {
        CSCallback = Callback;
    }
    //...
    
    if (CSCallback != nullptr)
        CSCallback->Exec( "Command", "Param" );
    
    C#
    public class CallbackImpl : ICallback
    {
        public void Exec(String Command, String Param)
        {
            //Execute some C# code, if you call UI stuff you will need to call this too
            //Deployment.Current.Dispatcher.BeginInvoke(() => { 
            // //Lambda code
            //}
        }
    }
    //...
    CallbackImpl CI = new CallbackImpl();
    D3DComponent.SetCallback( CI);
