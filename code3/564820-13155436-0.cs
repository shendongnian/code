    var attibutes = instance.GetType().GetInterfaces()
                        .SelectMany(i => i.GetProperties())
                        .SelectMany(
                            propertyInfo =>
                            propertyInfo.GetCustomAttributes(typeof (BarAttribute), false)
                        );
