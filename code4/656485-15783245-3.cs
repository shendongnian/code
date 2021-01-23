	//Creating a List of Fields (string FieldName, Type FieldType) 
	List<Field> Fields = new List<Field>();
	Fields.Add(new Field { FieldName = "TestName", FieldType = typeof(string) });
	//MyObjectBuilder Class
	MyObjectBuilder o = new MyObjectBuilder();
	//Creating a new object dynamically
	object newObj = o.CreateNewObject(Fields);
	IList objList = o.getObjectList();
	Type t = newObj.GetType();
	object instance = Activator.CreateInstance(t);
	PropertyInfo[] props = instance.GetType().GetProperties();
	int instancePropsCount = props.Count();
	for (int i = 0; i < instancePropsCount; ++i)
	{
	   string fieldName = props[i].Name;
	   MemberInfo[] mInfo = null;
	   PropertyInfo pInfo = newObj.GetType().GetProperty(fieldName);
	   if (pInfo != null)
	   {
		   var value = pInfo.GetValue(newObj, null);
		   mInfo = t.GetMember(fieldName);
		   if (value != null && mInfo != null && !string.IsNullOrEmpty(mInfo[0].ToString()))
			   SetMemberValue(mInfo[0], instance, value);
	   }
	   else
	   {
		   mInfo = t.GetMember(fieldName);
		   if (mInfo != null && !string.IsNullOrEmpty(mInfo[0].ToString()))
			   SetMemberValue(mInfo[0], instance, null);
	   }
	}
	objList.Add(instance);
	
