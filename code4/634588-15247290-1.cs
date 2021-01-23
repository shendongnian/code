        private void CreateRows(Int32 MaxBaseRows, Int32 MaxChildRows)
        {
            dataSet1.Clear();
            Int32 RowCount = 0;
            Random R = new Random();
            foreach (DataTable DT in dataSet1.Tables)
            {
                Int32 NewCount = R.Next(1, MaxBaseRows);
                foreach (var FK in DT.Constraints.OfType<ForeignKeyConstraint>())
                {
                    NewCount = NewCount * R.Next(1, MaxChildRows);
                }
                for (int i = 0; i < NewCount; i++)
                {
                    DataRow DR = DT.NewRow();
                    foreach (DataColumn DC in DT.Columns)
                    {
                        if (DC.ColumnName == "ID")
                        {
                            DR[DC] = DT.Rows.Count;
                        }
                        else if (DC.DataType == typeof(Int32))
                        {
                            Boolean ValueSet = false;
                            foreach (var FK in DT.Constraints.OfType<ForeignKeyConstraint>())
                            {
                                if (FK.Columns.Contains(DC))
                                {
                                    DR[DC] = R.Next(0, FK.RelatedTable.Rows.Count);
                                    ValueSet = true;
                                }
                            }
                            if (!ValueSet)
                            {
                                DR[DC] = R.Next(0, 10000);
                            }
                        }
                        else if (DC.DataType == typeof(String))
                        {
                            DR[DC] = String.Format("{0}{1}", DT.TableName, DT.Rows.Count);
                        }
                    }
                    DT.Rows.Add(DR);
                    RowCount++;
                }
            }
            label19.Text = RowCount.ToString();
            dataSet1.AcceptChanges();
        }
        private void UpdateUsingCascade()
        {
            EnableRelations();
            GC.Collect();
            long Mem = System.GC.GetTotalMemory(false);
            if (dataSet1.Tables["Planet"].Rows.Count > 0)
            {
                dataSet1.Tables["Planet"].Rows[0]["ID"] = new Random().Next(BaseRowCount, BaseRowCount + 10);
            }
            Mem = System.GC.GetTotalMemory(false) - Mem;
            DataSet ds = dataSet1.GetChanges();
            Int32 Changes = ds.Tables.OfType<DataTable>().Sum(DT => DT.Rows.Count);
            label19.Text = Changes.ToString();
            label21.Text = Mem.ToString();
            dataSet1.AcceptChanges();
        }
        private void UpdateManually()
        {
            DisableRelations();
            GC.Collect();
            long Mem = System.GC.GetTotalMemory(false);
            DataTable DT = dataSet1.Tables["Planet"];
            Int32 ChangeCount = 0;
            if (DT.Rows.Count > 0)
            {
                DataColumn DC = DT.Columns["ID"];
                Int32 oldValue = Convert.ToInt32(DT.Rows[0][DC]);
                DT.Rows[0][DC] = new Random().Next(BaseRowCount + 20,BaseRowCount + 30);
                Int32 newValue = Convert.ToInt32(DT.Rows[0][DC]);
                foreach (DataRelation Relation in DT.ChildRelations)
                {
                    if (Relation.ParentColumns.Contains(DC))
                    {
                        foreach (DataColumn CC in Relation.ChildColumns)
                        {
                            foreach (DataRow DR in Relation.ChildTable.Rows)
                            {
                                if (Convert.ToInt32(DR[CC]) == oldValue)
                                {
                                    DR[CC] = newValue;
                                    ChangeCount++;
                                    dataSet1.AcceptChanges();
                                    GC.Collect();
                                }
                            }
                        }
                    }
                }
            }
            Mem = System.GC.GetTotalMemory(false) - Mem;
            label20.Text = ChangeCount.ToString();
            label22.Text = Mem.ToString();
            dataSet1.AcceptChanges();
        }
        private void EnableRelations()
        {
            dataSet1.EnforceConstraints = true;
            foreach (DataRelation Relation in dataSet1.Relations)
            {
                Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade;
            }
        }
        private void DisableRelations()
        {
            dataSet1.EnforceConstraints = false;
            foreach (DataRelation Relation in dataSet1.Relations)
            {
                Relation.ChildKeyConstraint.UpdateRule = Rule.None;
            }
        }
