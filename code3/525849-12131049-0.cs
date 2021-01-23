    #if DEBUG
    using HiddenMember = global::DummyAttribute.HiddenMember;
    #else
    using HiddenMember = global::System.Diagnostics.DebuggerBrowsableAttribute;
    #endif
    
    namespace DummyAttribute
    {
        class HiddenMember : Attribute
        { public HiddenMember(DebuggerBrowsableState dummy) { } }
    }
