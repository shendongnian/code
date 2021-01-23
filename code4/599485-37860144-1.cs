    if (container.FunctionImports.Any())
    {
    #>
    using System.Data.Objects; // Error on compile
    using System.Data.Objects.DataClasses; // Error on compile
    using System.Linq;
    <#
