    <!-- System.XML.XmlReaderSettings changed after version 2.0.0.0.
         Define a constant to recognised that.
     -->
    <Target Name="SetupXMLDtdProcessing">
      <GetAssemblyIdentity AssemblyFiles="%(ReferencePath.Identity)"
                           Condition=" '%(ReferencePath.Filename)' == 'System.XML' "
      >
        <Output TaskParameter="Assemblies" ItemName="_SystemXMLAssemblyIdentityItem" />
      </GetAssemblyIdentity>
      <PropertyGroup>
        <_SystemXMLAssemblyIdentity>%(_SystemXMLAssemblyIdentityItem.Identity)</_SystemXMLAssemblyIdentity>
      </PropertyGroup>
    
      <PropertyGroup Condition=" '$(_SystemXMLAssemblyIdentity)' != 'System.Xml, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
                               "
      >
        <DefineConstants Condition=" '$(DefineConstants)' != '' ">$(DefineConstants);</DefineConstants>
        <DefineConstants>$(DefineConstants)XMLDTDPROCESSING</DefineConstants>
      </PropertyGroup>
    </Target>
    <PropertyGroup>
      <CompileDependsOn>
        SetupXMLDtdProcessing;
        $(CompileDependsOn)
      </CompileDependsOn>
    </PropertyGroup>
