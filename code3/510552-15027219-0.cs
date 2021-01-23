    <Target Name="AfterBuild" Condition="'$(Configuration)' == 'Release'">
        <GetAssemblyIdentity AssemblyFiles="$(TargetPath)">
            <Output TaskParameter="Assemblies" ItemName="AssemblyVersion" />
        </GetAssemblyIdentity>
        <Exec Command="echo %(AssemblyVersion.Version)" />
        <Message Text="Released %(AssemblyVersion.Version)" Importance="high" />
    </Target>
