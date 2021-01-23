    using namespace System::ComponentModel;
    public interface class IBar : public INotifyPropertyChanged {
    };
    
    public ref class Baz : ClassLibrary8::CFoo, IBar {
        // fine
    };
