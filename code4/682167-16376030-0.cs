           dynamic test = new ExpandoObject();
            var sourceMembers = typeof(ListofAccountingDocs2_1075).GetProperties();
       
    string[] selectparams =  parameters.Split(',');//property names are comma seperated
           
            foreach (var item in selectparams)
	          {		 
                  ((IDictionary<string, object>)test).Add(item,string.Empty); 
	          }
            IDictionary<string,object> test2 = new Dictionary<string,object>();
            List<PropertyInfo> destinationProperties = new List<PropertyInfo>();
            foreach (var item in ((IDictionary<string, object>)test))
            {
              var selectedColumn  = typeof(ListofAccountingDocs2_1075).GetProperties().FirstOrDefault(k =>
                 k.Name.Equals(item.Key));
              if (selectedColumn != null)
                  destinationProperties.Add(selectedColumn);
            }
            var name = "src";
            
            var parameterExpression = Expression.Parameter(typeof(ListofAccountingDocs2_1075), name);
            return Expression.Lambda<Func<ListofAccountingDocs2_1075, ListofAccountingDocs2_1075>>(
                Expression.MemberInit(
                    Expression.New(typeof(ListofAccountingDocs2_1075)),
                    destinationProperties.Select(k => Expression.Bind(k,
                        Expression.Property(
                            parameterExpression, k.Name)
                        )
                    ).ToArray()
                    ),
                parameterExpression
                );
        
        }
