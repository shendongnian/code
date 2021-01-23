    var ColName = "";
            var model = new AttributeMappingSource().GetModel(typeof(DataClassesDataContext));
            foreach (var mt in model.GetTables())
            {
                if (mt.TableName == "dbo.Table_Name")
                {
                    foreach (var dm in mt.RowType.DataMembers)
                    {
                        ColName = dm.MappedName + ", ";
                        Response.Write(ColName);
                    }
                }
            }
