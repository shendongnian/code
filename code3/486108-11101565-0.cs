        public static T CopyEntity<T>(T CopyFrom)
        {
            //Loop through all employee's members and copy the value to a new instance
            T obj = (T)Activator.CreateInstance(typeof(T));
            foreach (System.Reflection.PropertyInfo propInfo in typeof(T).GetProperties())
            {
                //Get prop value
                object valueToCopy = propInfo.GetValue(CopyFrom, null);
                //Set the prop value
                propInfo.SetValue(obj, valueToCopy, null);
            }
            return obj;
        }
        public static List<T> BuildTree<T>(List<T> list, T selectedNode, string keyPropName, string parentPropName, int endLevel = 0, int level = 0)
        {
            List<T> entity = new List<T>();
            Type type = typeof(T);
            PropertyInfo selectedNodekeyProp = type.GetProperty(keyPropName);
            string _selectedNodekey = selectedNodekeyProp.GetValue(selectedNode, null).ToString();
            foreach (T item in list)
            {
                
                PropertyInfo keyProp = type.GetProperty(keyPropName);
                string _key = keyProp.GetValue(item, null).ToString();
                PropertyInfo parentProp = type.GetProperty(parentPropName);
                string _parent = parentProp.GetValue(item, null).ToString();
                if (_selectedNodekey == _parent)
                {
                    T obj = (T)Activator.CreateInstance(typeof(T));
                    obj = CopyEntity<T>(item);
                    entity.Add(obj);
                    if (level == endLevel && level!=0) break;
                    list.Remove(obj);
                    entity.AddRange(BuildTree<T>(list, obj, keyPropName, parentPropName, level + 1));
                }
            }
            return entity;
        }
