                    // Format the parameters based on our requirements: 
                StringBuilder parameters = new StringBuilder();
                foreach (var p in filterContext.ActionDescriptor.GetParameters())
                {
                    if (filterContext.Controller.ValueProvider.GetValue(p.ParameterName) != null)
                    {
                        parameters.AppendFormat("\r\n\t{0}\t\t:{1}", p.ParameterName,
                                                filterContext.Controller.ValueProvider.GetValue(p.ParameterName).AttemptedValue);
                    }
                }
