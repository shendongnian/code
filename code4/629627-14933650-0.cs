    if (context != null)
                {
                    AttributeCollection ua = context.PropertyDescriptor.Attributes;                    
                    ParamDesc cca = (ParamDesc)ua[typeof(ParamDesc)];    
                    if (cca != null)
                       System.Console.WriteLine("Attribute value is " + cca.DictID.ToString());
                }
