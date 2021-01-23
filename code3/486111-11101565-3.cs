        public static List<T> BuildTree<T>(List<T> list, T selectedNode, string keyPropName, string parentPropName, int endLevel = 0, int level = 0)
        {
            List<T> entity = new List<T>();
            Type type = typeof(T);
            PropertyInfo keyProp = type.GetProperty(keyPropName);
            string _selectedNodekey = keyProp.GetValue(selectedNode, null).ToString();
            
            PropertyInfo parentProp = type.GetProperty(parentPropName);
            foreach (T item in list)
            {
                string _key = keyProp.GetValue(item, null).ToString();
                string _parent = parentProp.GetValue(item, null).ToString();
                if (_selectedNodekey == _parent)
                {
                    T obj = (T)Activator.CreateInstance(typeof(T));
                    obj = item;
                    entity.Add(obj);
                    if (level == endLevel && level!=0) break;
                    entity.AddRange(BuildTree<T>(list, obj, keyPropName, parentPropName, level + 1));
                }
            }
            return entity;
        }
