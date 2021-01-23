c#
    var simpleProperties = typeMapper.GetSimpleProperties(entity);
    if (simpleProperties.Any())
    {
        foreach (var edmProperty in simpleProperties)
        {
#>
	[DataMember]
    <#=codeStringGenerator.Property(edmProperty)#>
<#
        }
    }
Some part of the code above should already be in the T4 file. you might need to find it and modify it by adding ``[DataMember]`` to it.
Also, you can create your DTO file in an arbitrary location with desired attributes. For example the code below is creating an interface for all the entities in a folder named *Interface* and also name the interface like *I{EntityName}Repository.cs*. You can generate DTOs in the same way.
c#
foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
{
	var host = this.Host.ResolvePath("App.config");
	var savepath = host.Replace("App.config","")+"Interface\\" + "I"+entity.Name+"Repository" +".cs";
	var readpath = host.Replace("App.config","") + "Templates\\";
    if (!File.Exists(savepath))
    {
		using (StreamReader sr = new StreamReader(readpath+"RepositoryInterfaceTemplate.txt"))
     {
                String line = sr.ReadToEnd();
               line = line.Replace("{RepositoryInterface}","I"+entity.Name+"Repository");
				line =line.Replace("{EntityName}",entity.Name);
            
   
		using (StreamWriter sw = File.CreateText(savepath))
		{		
			sw.WriteLine(@line);	    
		}
	  }
	}
}
