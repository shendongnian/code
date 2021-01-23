    // I obtain anykeys by iterating through the entity keys:
    _anyKeys = string.Format("{0}{1} item.{2} == {3}_dto.{2}", _anyKeys, _and, key.ToString(), _double);
    	// loop through all the entities:
    	foreach (EntityType entity in Item1Collection.GetItems<EntityType>().OrderBy(e => e.Name))
    	{
    
    	/// <summary>
    	/// <#=code.Escape(entity)#> Operation contracts - <#=code.Escape(entityName)#> 
    	/// </summary>	
    	[WebMethod]
    	public bool Save<#=code.Escape(entity)#>(Dto<#=code.Escape(entity)#> _dto, int racID, string profile)
    	{
    		try
    		{
    			// Load the db
    			using (<#=ContextName#> db = new <#=ContextName#>(EFUtils.GetEFConnectionString(profile, modelName)))
    			{
    				// Check if item exists			
    				var exists = db.<#=code.Escape(entityName)#>.Any(item=> <#=code.Escape(_anyKeys)#>);
    				// convert to entity
    				var _entity = _dto.ToEntity();
    				if(exists)
    				{
    				  // Attach the entity to the db
    				  db.<#=code.Escape(entityName)#>.Attach(_entity);
    				  // Change tracking
    				  ChangeTracking<<#=code.Escape(entity)#>>(_dto.ModifiedProperties, db, _entity);
    				}
    				else
    				{
    				  // New entity
    				  db.<#=code.Escape(entityName)#>.Add(_entity);
    				}
    				// Save changes
    				return db.SaveChanges() > 0;
    			}
    		}
    		catch(Exception ex)
    		{				
    			Global.LogMessageToFile(ex, string.Format("{0} - profile {1}, Save<#=code.Escape(entity)#>", racID, profile));
    		}
    		finally
    		{		
    		}
    		return false;
    	}
    
    
    // Then the interfaces
    #>
    #region <#=code.Escape(entity)#>
    	/// <summary>
    	/// <#=code.Escape(entity)#> Operation contracts - <#=code.Escape(entity.Name)#> 
    	/// </summary>	
    	[OperationContract]
    	bool Save<#=code.Escape(entity)#>(Dto<#=code.Escape(entity)#> _dto, int racID, string profile);
    	[OperationContract]
    	bool Delete<#=code.Escape(entity)#>(<#=code.Escape(_keys)#>, int racID, string profile);
    	[OperationContract]
    	Dto<#=code.Escape(entity)#> Get<#=code.Escape(entity)#>(<#=code.Escape(_keys)#>, string  filterXml, int racID, string profile);
    	[OperationContract]
    	List<Dto<#=code.Escape(entity)#>> List<#=code.Escape(entityName)#>(string  filterXml, int racID, string profile);	
    #endregion
    <#+ 
