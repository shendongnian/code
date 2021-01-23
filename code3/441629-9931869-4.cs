    //GatewayCode.h
    //GatewayLibrary is the tricky part,
    //Here we listen events from the native library
    //and propagate them to .net/clr world
    #ifndef _GATEWAY_CODE_H_
    #define _GATEWAY_CODE_H_
    #include "../NativeLibrary/NativeCode.h" //include native library
    #include <vcclr.h> //required for gcroot
    namespace GatewayLibrary{
        //EventGateway fires .net event when a native event happens.
        //It is the actual gateway class between Native C++ and .NET world.
        //In other words, It RECEIVES NATIVE events, TRANSFORMS/SENDS them into CLR.
        public ref class EventGateway {
        public:
            //ctor, its implementation placed below
            EventGateway();
            //required to clean native objects
            ~EventGateway();
            !EventGateway();
            //the SENDER part
            //.net event stuff defined here
            delegate void DotNetEventHandler();
            event DotNetEventHandler^ OnEvent;
        private:
            //our native library code
            //notice you can have pointers to native objects in ref classes.
            NativeCode* nativeCode_; 
            
            //the required device to listen events from the native library
            INativeListener* nativeListener_; 
        internal: //hide from .net assembly
            //the RECEIVER part, called when a native event received
            void OnNativeEvent(){
                //you can make necessary transformation between native types and .net types
                //fire .net event
                OnEvent();
            }
        };
    }
    //A concrete listener class. we need this class to register native library events.
    //Its our second gateway class which connects Native C++ and CLI/C++
    //It basically gets events from NativeLibary and sends them to EventGateway
    class NativeListenerImp : public INativeListener {
    public:
        NativeListenerImp(gcroot<GatewayLibrary::EventGateway^> gatewayObj ){
            dotNetGateway_ = gatewayObj;
        }
        //this is the first place we know that a native event has happened
        virtual void OnEvent(){
            //inform the .net gateway which is responsible of transforming native event to .net event
            dotNetGateway_->OnNativeEvent();
        }
    private:
        //class member to trigger .net gateway.
        //gcroot is required to declare a CLR type as a member of native class.
        gcroot<GatewayLibrary::EventGateway^> dotNetGateway_;
    };
    ////ctor and dtors of EventGateway class
    GatewayLibrary::EventGateway::EventGateway()
    {
        nativeCode_ = new NativeCode();
        //note; using 'this' in ctor is not a good practice
        nativeListener_ = new NativeListenerImp(this);
    }
    GatewayLibrary::EventGateway::~EventGateway()
    {
        //call the non-deterministic destructor
        this->!EventGateway();
    }
    GatewayLibrary::EventGateway::!EventGateway()
    {
        //clean up native objects
        delete nativeCode_;
        delete nativeListener_;
    }
    #endif
