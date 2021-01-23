    <#
    string edmxFile = @"../Entities/NorthwindEntities.edmx";
    CodeGenerationTools code = new CodeGenerationTools(this);
    MetadataLoader loader = new MetadataLoader(this);
    string modelNamespace = loader.GetModelNamespace(edmxFile);
    #>
    using System;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using <#=code.Escape(modelNamespace)#>;
