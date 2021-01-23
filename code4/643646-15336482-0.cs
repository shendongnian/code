    string Date_Gather = string.Format(@"         
	 <fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
	                    <entity name='new_import'>                       
         
                                    <attribute name='new_enddate'  /> 
                                                
			            </entity>
           </fetch>", entity.Id);
    foreach (var b in Date_Gather_result.Entities)
                        {
    if (b.Attributes.Contains("new_enddate"))
                            {
                                enddate = ((DateTime)(b["new_enddate"]));
                                Entity.Attributes.Add("scheduledend", enddate);
                            }
                         }
