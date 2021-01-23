    public ref class CppClassWithMembers
    {
    public:
        long long Id;
        System::DateTime CreateDateTime;
        System::String^ Name;
    
        CppClassWithMembers() : CreateDateTime(System::DateTime::Now) { }
    };
