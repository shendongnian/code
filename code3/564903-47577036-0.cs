        public class JoinKey
        {
            List<object> objects { get; set; }
            public JoinKey(List<object> objects)
            {
                this.objects = objects;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || obj.GetType() != typeof(JoinKey))
                    return false;
                return objects.SequenceEqual(((JoinKey)obj).objects);
            }
            public override int GetHashCode()
            {
                int hash = 0;
                foreach (var foo in objects)
                {
                    hash = hash * 31 + foo.GetHashCode();
                }
                return hash;
            }
        }
        public enum JoinType
        {
            Inner = 0,
            Left = 1
        }
            //Joins two tables and spits out the joined new DataTable. Tables are joined on onCol column names
            //If the right table has column name clashes with the left column, the column names will be appended "_2" and added to joined table
            public static DataTable Join(DataTable left, DataTable right, JoinType joinType, params string[] onCol)
            {
                Func<DataRow, object> getKey = (row) =>
                {
                    return new JoinKey(onCol.Select(str => row[str]).ToList());
                };
                var dt = new DataTable(left.TableName);
                var colNumbersToRemove = new List<int>();
                //Populate the columns
                foreach (DataColumn col in left.Columns)
                {
                    if (dt.Columns[col.ColumnName] == null)
                        dt.Columns.Add(new DataColumn(col.ColumnName, col.DataType, col.Expression, col.ColumnMapping));
                }
                for (int colIdx = 0; colIdx < right.Columns.Count; ++colIdx)
                {
                    var col = right.Columns[colIdx];
                    //if this is joined column, it will be removed.
                    if (onCol.Contains(col.ColumnName))
                    {
                        colNumbersToRemove.Add(colIdx);
                    }
                    else
                    {
                        //if this is duplicate column, it will be renamed.
                        if (dt.Columns[col.ColumnName] != null)
                        {
                            col.ColumnName += "_2";
                        }
                        dt.Columns.Add(new DataColumn(col.ColumnName, col.DataType, col.Expression, col.ColumnMapping));
                    }
                }
    
                if (joinType == JoinType.Left)
                {
                    var res = from l in left.AsEnumerable()
                              join r in right.AsEnumerable()
                              on getKey(l) equals getKey(r) into temp
                              from r in temp.DefaultIfEmpty()
                              select l.ItemArray.Concat(((r == null) ? (right.NewRow().ItemArray) : r.ItemArray).Minus(colNumbersToRemove)).ToArray();
                    foreach (object[] values in res)
                        dt.Rows.Add(values);
                }
                else
                {
                    //Inner Join
                    var res = from l in left.AsEnumerable()
                              join r in right.AsEnumerable()
                              on getKey(l) equals getKey(r) into temp
                              from r in temp
                              select l.ItemArray.Concat(((r == null) ? (right.NewRow().ItemArray) : r.ItemArray).Minus(colNumbersToRemove)).ToArray();
                    foreach (object[] values in res)
                        dt.Rows.Add(values);
                }
                return dt;
            }
