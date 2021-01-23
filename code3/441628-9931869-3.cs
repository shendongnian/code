    #ifndef _NATIVE_CODE_H_
    #define _NATIVE_CODE_H_
    //NativeCode.h
    //A simple native library which emits only one event.
    #include <stdlib.h>
    #define NATIVELIBRARY_API __declspec(dllexport)
    //A simple mechanism to fire an event from native code.
    //Your library may have a DIFFERENT triggering mechanism (e.g. function pointers)
    class INativeListener
    {
    public:
        virtual void OnEvent()=0;
    };
    //The actual native library code, source of native events
    class NATIVELIBRARY_API NativeCode
    {
    public:
        NativeCode()
            :theListener_(NULL)
        {}
        //Listener registration method
        void registerListener(INativeListener* listener) {
            theListener_ = listener;
        }
        //this is the very first source of the event
        //native code emits the event via the listener mechanism
        void eventSourceMethod() {
            //... other stuff
            //fire the native event to be catched
            if(theListener_){
                theListener_->OnEvent();
            }
        }
    private:
        //native code uses a listener object to emit events
        INativeListener* theListener_;
    };
    #endif
