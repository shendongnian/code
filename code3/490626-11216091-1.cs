    // C++ Const declaration
    namespace MyNameSpace {
    public ref class ConstClass {
    public:
         literal int AttributeConstValue = 15 + sizeof(int);
    . . .
    }
    // C# Usage
    [MarshalAs(UnmanagedType.ByValArray, SizeConst=MyNameSpace.ConstClass.AttributeConstValue)]
    public byte [] results;
