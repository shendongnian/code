       <#@ template debug="false" hostspecific="false" language="C#" #>
       <#@ import namespace="System.Data" #>
       <#@ import namespace="System.Data.SqlClient" #>
       <#@ assembly name="System.Data" #>
       namespace Some.Namespace
       {
           public class TestClass 
           {
		<# 
		using(var cnn = new SqlConnection(@"server=.\sqlexpress;Integrated Security=SSPI;Database=ApplicationManagement"))
		{
			cnn.Open();
			var cmd = new SqlCommand("SELECT TextKey, TextValue FROM TblBrandingKeyValues WHERE BrandingIdentifier = 'Default'", cnn);
			
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				var defaultText = reader.GetString(1);
				var name = reader.GetString(0);
		
		
		#>
		public string <#= name #> 
		{
			get { return "<#= defaultText #>"; } 
		}
		
		<#
			}
		}
		
		 #>
		}
    }
