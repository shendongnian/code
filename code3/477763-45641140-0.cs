    return
        type.IsClass && // I need classes
        !type.IsAbstract && // Must be able to instantiate the class
        !type.IsNestedPrivate && // Nested private types are not accessible
        !type.Assembly.GlobalAssemblyCache && // Excludes most of BCL and third-party classes
        type.Namespace != null && // Yes, it can be null!
        !type.Namespace.StartsWith("System.") && // EF, for instance, is not in the GAC
        !type.Namespace.StartsWith("DevExpress.") && // Exclude third party lib
        !type.Namespace.StartsWith("CySoft.Wff") && // Exclude my own lib
        !type.Namespace.EndsWith(".Migrations") && // Exclude EF migrations stuff
        !type.Namespace.EndsWith(".My") && // Excludes types from VB My.something
        !typeof(Control).IsAssignableFrom(type) && // Excludes Forms and user controls
        type.GetCustomAttribute<CompilerGeneratedAttribute>() == null && // Excl. compiler gen.
        !typeof(IControllerBase).IsAssignableFrom(type); // Specific to my project
