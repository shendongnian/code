    <Target Name="BeforeBuild">
    	<ItemGroup>
         <AssemblyAttributes Include="AssemblyTitle">
    		<_Parameter1>My Assembly</_Parameter1>
    	 </AssemblyAttributes>
         <AssemblyAttributes Include="AssemblyDescription">
    		<_Parameter1>My Assembly</_Parameter1>
    	 </AssemblyAttributes>	
         <AssemblyAttributes Include="AssemblyCompany">
    		<_Parameter1>My Company</_Parameter1>
    	 </AssemblyAttributes>
         <AssemblyAttributes Include="AssemblyProduct">
    		<_Parameter1>My Product</_Parameter1>
    	 </AssemblyAttributes>
         <AssemblyAttributes Include="AssemblyCopyright">
    		<_Parameter1>Copyright © 2012</_Parameter1>
    	 </AssemblyAttributes>
         <AssemblyAttributes Include="AssemblyCulture">
    		<_Parameter1></_Parameter1>
    	 </AssemblyAttributes>		 
         <AssemblyAttributes Include="AssemblyVersion">
    		<_Parameter1>1.0.0.0</_Parameter1>
    	 </AssemblyAttributes>	 
         <AssemblyAttributes Include="AssemblyFileVersion">
    		<_Parameter1>1.0.0.0</_Parameter1>
    	 </AssemblyAttributes>
         <AssemblyAttributes Include="System.Runtime.InteropServices.Guid">
    		<_Parameter1>e7a979b2-0a4f-483a-ba60-124e7ef3a931</_Parameter1>
    	 </AssemblyAttributes>
    	</ItemGroup>
      <WriteCodeFragment Language="C#" OutputFile="Properties/AssemblyInfo.cs" AssemblyAttributes="@(AssemblyAttributes)" />
    </Target>
