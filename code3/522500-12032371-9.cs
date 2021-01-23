    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ include file="Enum2D.ttinclude" #>
    <#@ output extension=".cs" #><#=
    	BuildEnum2D
    	(
    		"Enum2DTest",
    		"Cars",
    		new Tuple<string, IEnumerable<string>>[]
    		{
    			new Tuple<string, IEnumerable<string>>
    			(
    				"Ferrari",
    				new string[]
    				{
    					"California",
    					"Enzo",
    					"Testarossa"
    				}
    			),
    			new Tuple<string, IEnumerable<string>>
    			(
    				"Ford",
    				new string[]
    				{
    					"Corsair",
    					"Cortina",
    					"Galaxy",
    					"GT"
    				}
    			)
    		}
    	)
    #>
