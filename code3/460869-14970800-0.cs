                    // Format the parameters based on our requirements: 
                StringBuilder parameters = new StringBuilder();
                foreach (var p in filterContext.ActionDescriptor.GetParameters())
                {
                    parameters.AppendFormat("{0}\t\t:{1}", p.ParameterName,
                                            filterContext.Controller.ValueProvider.GetValue("id").AttemptedValue);
                }
