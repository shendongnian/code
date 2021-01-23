    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    using System;
    namespace MyNamespace 
    {
      public partial class Generated 
      {
      <# 
        var desiredTypes = new[] { "int", "float", "double" };
        foreach(var type in desiredTypes) {
      #>
      private <#=type#> SomeFunctionA(<#=type#>[][,] d)
      {
          <#=type#> sum = 0; 
          for (int k = 0; k < d.GetLength(0); k++)
              for (int j = 0; j < d[0].GetLength(1); j++)
                  for (int i = 0; i < d[0].GetLength(0); i++)
                        sum += d[k][i,j];
          return SomeFunctionB(sum);
      }
      private <#=type#> SomeFunctionB(<#=type#> input)
      {
        return default(<#=type#>);
      }
      <# } #>
      }
    }
