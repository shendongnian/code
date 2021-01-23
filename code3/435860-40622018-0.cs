        object singleval;
        Array arrayval;
        System.Type LocalPType = obj.GetType().GetField(node.Name).FieldType;
        if (LocalPType.IsArray)
        {
            singleval = TreeNodeProperty.CreateNewInstance(LocalPType.GetElementType());
            arrayval =  Array.CreateInstance(LocalPType, 10);
            for(int i = 0; i < 10; i++)
            {
                singleval = PopulateInstance(singleval, node);
                arrayval.SetValue(singleval, i);
            }
            obj.GetType().GetField(node.Name).SetValue(obj, arrayval);
        }
        else
        {
            object val;
            val = Activator.CreateInstance(LocalPType);
            obj.GetType().GetField(node.Name).SetValue(obj,         PopulateInstance(val, node));
        }
