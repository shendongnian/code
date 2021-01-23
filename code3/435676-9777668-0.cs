    void WriteProperty(string accessibility, string type, string name, string getterAccessibility,  string setterAccessibility)
    {
      //Start New Stuff
      string[] names = name.Split('_');
      names = names.ToList().Select(x => char.ToUpper(x[0]) + x.Substring(1)).ToArray();
      string fixedName = string.Join("", names);
     //End New Stuff
    #>
      [Column(Name="<#=name>")]
      <#=accessibility#> <#=type#> <#=fixedName#> { <#=getterAccessibility#>get; <#=setterAccessibility#>set; }
    <#+
    }   
