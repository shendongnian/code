    using System.Runtime.CompilerServices;
    
    // making internals available to the testing project
    [assembly: InternalsVisibleTo( "MyProject.IntegrationTests" )]
    [assembly: InternalsVisibleTo( "MyProject.UnitTests" )]
