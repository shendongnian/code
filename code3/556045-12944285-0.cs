    public class ModelBinder : DefaultModelBinder
    {
        public override object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var ModelType = bindingContext.ModelType;
            var Instance = Activator.CreateInstance(ModelType);
            var Form = bindingContext.ValueProvider;
            foreach (var Property in ModelType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                Type PropertyType = Property.PropertyType;
                
                // I'm using an ORM so this checks whether or not the property is a
                // reference to another object
                if (!(PropertyType.GetGenericArguments().Count() > 0 ))
                {
                    // This is the not so generic part.  It really just checks whether or 
                    // not it is a custom object.  Also the .Load() method is specific
                    // to the ORM
                    if (PropertyType.FullName.StartsWith("Objects.Models"))
                    {
                        var Load = PropertyType.GetMethod("Load", BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static, null, new Type[] { typeof(long) }, null);
                        var Value = Load.Invoke(new object(), new object[] { long.Parse(Form.GetValue(Property.Name + ".ID").AttemptedValue) });
                        Property.SetValue(Instance, Value, null);
                    }
                    // checkboxes are weird and require a special case
                    else if (PropertyType.Equals(typeof(bool)))
                    {
                        if (Form.GetValue(Property.Name) == null)
                        {
                            Property.SetValue(Instance, false, null);
                        }
                        else if (Form.GetValue(Property.Name).Equals("on"))
                        {
                            Property.SetValue(Instance, true, null);
                        }
                    }
                    else
                    {
                        Property.SetValue(Instance, Convert.ChangeType(bindingContext.ValueProvider.GetValue(Property.Name).AttemptedValue, PropertyType), null);
                    }
                }
            }
            return Instance;
        }
    }
