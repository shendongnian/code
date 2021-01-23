        public static class Extensions 
        {
                public static DataTable ToDataTable<T>(this IList<T> data)
                {
                    PropertyDescriptorCollection propriedades = TypeDescriptor.GetProperties(typeof(T));
                    DataTable dtTabela = new DataTable();
                    for (int i = 0; i < propriedades.Count; i++)
                    {
                        PropertyDescriptor prop = propriedades[i];
                        dtTabela.Columns.Add(prop.Name, prop.PropertyType);
                    }
                    object[] objValores = new object[propriedades.Count];
                    foreach (T item in data)
                    {
                        for (int i = 0; i < objValores.Length; i++)
                    {
                    objValores[i] = propriedades[i].GetValue(item);
                }
                dtTabela.Rows.Add(objValores);
            }
            return dtTabela;
        }
