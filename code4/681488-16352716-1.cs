       public class handlerName : IHttpHandler
        {
    
    	public void ProcessRequest(HttpContext context)
            {
                try
                {
                    // THOSE PARAMETERS ARE SENT BY THE PLUGIN
                    var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
    
                    ////HOLD DISPLAY START
                    var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
    
                    ////HOLD SORT COLUMN
                    var iSortCol = int.Parse(context.Request["iSortCol_0"]);
    
                    ////HOLD SORT DIRECTION SUCH AS ASC AND DESC
                    var iSortDir = context.Request["sSortDir_0"];
    
                    ////HOLD SEARCH KEYWORD
                    var sSearch = context.Request["sSearch"];             
    
    
                    var variableToHoldData = className.functionName();
    
                    // DEFINE AN ORDER FUNCTION BASED ON THE ISORTCOL PARAMETER
                    Func<variableToHoldData, object> order = p =>
                    {
                        //IF SORT COLUMN IS 1, fieldName
                       if (iSortCol == 1)
                       {
                            return p.fieldName2;
                       }
                    //    //IF SORT COLUMN IS 2, SORT BY fieldName
                       else if (iSortCol == 2)
                       {
                            return p.fieldName3;
                        }
                
                        }
                        //SORT BY fieldName
                       return p.fieldName1;
                    };
                    // DEFINE THE ORDER DIRECTION BASED ON THE ISORTDIR PARAMETER
                    variableToHoldData = "desc" == iSortDir ? variableToHoldData.OrderByDescending(order) : variableToHoldData.OrderBy(order);
    
    
                    // PREPARE AN ANONYMOUS OBJECT FOR JSON SERIALIZATION
                    var result = new
                    {
                        iTotalRecords = variableToHoldData.Count(),
                        iTotalDisplayRecords = variableToHoldData.Count(),
                        aaData = variableToHoldData
    
                            //SEARCH BY FIELD NAME
                            .Where(p => p.fieldName1.ToLower().Contains(sSearch.ToLower()) || p.fieldName2.ToLower().Contains(sSearch.ToLower()) || p.fieldName3.ToLower().Contains(sSearch.ToLower()) )
    
                            //SELECT FIELDS
                            .Select(p => new[] { p.fieldName1.ToString(), p.fieldName2.ToString(), p.fieldName3.ToString() })
                            .Skip(iDisplayStart)
                            .Take(iDisplayLength)
    
                    };
    
                    var serializer = new JavaScriptSerializer();
    
                    //CONVERT RESULT INTO JSON
                    var json = serializer.Serialize(result);
                    context.Response.ContentType = "application/json";
                    context.Response.Write(json);
    
                }
                catch (Exception)
                {
    
                    throw;
                }
    
            }
    	       public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }	
    		
    		
    		
    	public class className
        {
            public string fieldName1 { get; set; }
            public string fieldName2 { get; set; }
            public string fieldName3 { get; set; }
    
    		
    		public static IEnumerable<className> functionName()
            {
    
            
                //RETURN DATA FROM SOURCE
                DT= obj.ReturnData();
    
                //CHECK CANDIDATE PROFILE DATATABLE  IS NULL
                if (DT != null && DT.Rows.Count > 0)
                {
                    
                    foreach (DataRow row in DT.Rows)
                    {
                        yield return new className
                        {
                            
    
                           
                            fieldName1 = row["columnName1"].ToString(),
    
                           
                            fieldName1 = row["columnName2"].ToString(),
    
                           
                            fieldName1 = row["columnName3"].ToString(),                 
    
                          
                        };
                    }
                }
    
            }
    
        }
    		}
     
