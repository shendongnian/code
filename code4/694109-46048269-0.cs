            MyContext ctx = new MyContext();
            var metadata = ((IObjectContextAdapter)ctx).ObjectContext.MetadataWorkspace;
            var schema = metadata.GetItems(DataSpace.SSpace).ToList();
            Dictionary<string, List<string>> tables = new Dictionary<string, List<string>>();
            Dictionary<string, System.Data.Entity.Core.Metadata.Edm.EntityType> types = new Dictionary<string, System.Data.Entity.Core.Metadata.Edm.EntityType>();
            Dictionary<string, string> table_names = new Dictionary<string, string>();
            foreach (var item in schema)
            {
                if (item.ToString().Contains("CodeFirstDatabaseSchema") && !item.ToString().Contains("_"))
                {
                    string[] tableItem = item.ToString().Split('.');
                    string name = tableItem[1];
                    Debug.WriteLine("table_name: " + name);
                    if (!tables.ContainsKey(name))
                    {
                        System.Data.Entity.Core.Metadata.Edm.EntityType entity_type = item as System.Data.Entity.Core.Metadata.Edm.EntityType;
                        if (entity_type != null)
                        {
                            List<string> columns = new List<string>();
                            var members = entity_type.DeclaredMembers;
                            foreach (var member in members)
                            {
                                columns.Add(member.ToString());
                            }
                            Debug.WriteLine("columns:\n" + string.Join(",", columns));
                            tables.Add(name, columns);
                            types.Add(name, entity_type);
                            table_names.Add(name, item.MetadataProperties["TableName"].Value.ToString());
                        }
                    }
                }
            }
            foreach (var table_name in tables.Keys)
            {
                List<string> columns = tables[table_name];
                System.Data.Entity.Core.Metadata.Edm.EntityType entity = types[table_name];
                string table_csv_name = table_names[table_name] + ".csv";
                Debug.WriteLine("table_csv_name: " + table_csv_name);
                var assembly_name = AssemblyName.GetAssemblyName("MyDLL.dll");
                var proxy = metadata.GetItems<System.Data.Entity.Core.Metadata.Edm.EntityType>(DataSpace.OSpace).Where(v => v.Name == table_name).FirstOrDefault();
                Type proxy_type = Type.GetType(proxy.FullName + ", " + assembly_name.FullName);
                if (proxy_type != null)
                {
                    var set = ctx.Set(proxy_type);
                    foreach (var row in set)
                    {
                        Debug.WriteLine("row: " + row);
                    }
                }
            }
