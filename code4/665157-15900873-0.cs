        var dt = new DataTable();
        var dataList = (from DataRow row in dt.Rows
                    select new SomeObject
                    {
                        Id = Convert.ToInt32(row["Id"])
                    }).ToList();
        dataList = dataList.Distinct(new SomeDistinctComparer()).ToList();
        public class SomeObject
        {
            public int Id { get; set; }
        }
        public class SomeDistinctComparer : IEqualityComparer<SomeObject>
        {
            public bool Equals(SomeObject x, SomeObject y)
            {
                return x.Id == y.Id;
            }
            public int GetHashCode(SomeObject obj)
            {
                return obj.Id.GetHashCode();
            }
        }
