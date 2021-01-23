    using Engine.Configuration;
    namespace Engine
    {
        // This will still work.
        Engine.Configuration.Configuration;
    
        // This will break, do we mean "Engine.Configuration.Configuration" or "Engine.Configuration"?
        Configuration;
    }
