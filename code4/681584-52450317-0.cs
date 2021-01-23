       public void PrintProperties(TreeNode parentNode, object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = new object();
                if (property.CanRead)
                    propValue = property.GetValue(obj, null);
                if (IsSimpleType(property.PropertyType))
                {
                    //Console.WriteLine("{0}{1}:", indentString, property.Name);
                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(property.Name, property.Name +": " + (propValue != null ? propValue.ToString() : string.Empty));
                    }
                    else
                    {
                        treeView.Nodes.Add(property.Name, property.Name + ": " + (propValue != null ? propValue.ToString() : string.Empty));
                    }
                    
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    TreeNode node;
                    if (parentNode != null)
                    {
                        node = parentNode.Nodes.Add(property.Name, property.Name);
                    }
                    else
                    {
                        node = treeView.Nodes.Add(property.Name, property.Name);
                    }
                    //Console.WriteLine("{0}{1}:", indentString, property.Name);
                    IEnumerable enumerable = (IEnumerable)propValue;
                    foreach (object child in enumerable)
                        PrintProperties(node, child, indent + 2);
                }
                else
                {
                    TreeNode node;
                    if (parentNode != null)
                    {
                        node = parentNode.Nodes.Add(property.Name, property.Name);
                    }
                    else
                    {
                        node = treeView.Nodes.Add(property.Name, property.Name);
                    }
                    PrintProperties(node, propValue, indent + 2);
                }
            }
        }
        public static bool IsSimpleType(Type type)
        {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new Type[]
                {
            typeof(String),
            typeof(Decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }
