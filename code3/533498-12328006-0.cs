    using System.Data;
    using System.Xml.Linq;
    using System.Linq;
    
    class Program
    {
    
    	public static void Main()
    	{
    		XDocument document = XDocument.Parse(
    			@"
    				<Registrations>
    				  <RegistrationForm>
    					<RegValue Id=""Passport"" v=""13.999.567"" />
    					<RegValue Id=""FavoriteColor"" v=""Blue"" />
    					<RegValue Id=""Gender"" v=""Male"" />
    				  </RegistrationForm>
    				  <RegistrationForm>
    					<RegValue Id=""Passport"" v=""12.566.342"" />
    					<RegValue Id=""FavoriteColor"" v=""Red"" />
    					<RegValue Id=""Gender"" v=""Female"" />
    				  </RegistrationForm>
    				</Registrations>
    			"
    		);
    
    		DataTable table = new DataTable();
    
    		XElement firstElement = document
    								.Root
    								.Elements(
    									"Registrations"
    								)
    								.Elements(
    									"RegistrationForm"
    								)
    								.FirstOrDefault();
    
    
    		if (firstElement == null)
    
    			return;
    
    		table
    		.Columns
    		.AddRange(
    			firstElement
    			.Elements(
    				"RegValue"
    			)
    			.Select(
    				e =>
    				new DataColumn(e.Attribute("Id").Value)
    			)
    			.ToArray()
    		);
    
    		table
    		.Rows
    		.Add(
    			document
    			.Root
    			.Elements(
    				"Registrations"
    			)
    			.Elements(
    				"RegistrationForm"
    			)
    			.Select(
    				e =>
    				e
    				.Elements()
    				.Select(
    					regValue =>
    					regValue
    					.Attribute("v")
    					.Value
    				)
    				.ToArray()
    			)
    		);
    
    		//YOUR TABLE IS READY HERE.
    	}
    }
