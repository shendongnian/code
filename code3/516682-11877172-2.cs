    /// <summary>
    /// Class for a ObjectDataSource
    /// </summary>
    [DataObject]
    public class FilterGridViewODS
    {
        private static IList<MyDataPoco> MyDataList = new List<MyDataPoco>();
        /// <summary>
        /// Static constructor. Creates a list of 50 items.
        /// </summary>
        static FilterGridViewODS()
        {
            for (int i = 0; i < 50; i++)
            {
                MyDataList.Add(
                    new MyDataPoco()
                    {
                        Id = i.ToString(),
                        Name = "Name " + i,
                        Phone = i + "" + i + "" + i + "." + i + "" + i + "" + i + "" + i + ""
                    });
            }
        }
        /// <summary>
        /// if <paramref name="doQuery"/> is <c>true</c>, performs a 
        /// query over the data content, Otherwise return an empty list.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<MyDataPoco> QueryMyDataPoco(String id, String name, String phone, bool doQuery)
        {
            if (doQuery)
            {
                IEnumerable<MyDataPoco> filteredEnum =
                    from md in MyDataList
                    where
                        md.Id.Contains(id)
                        && md.Name.Contains(name)
                        && md.Phone.Contains(phone)
                    select md;
                return filteredEnum;
            }
            else
            {
                //returning an empty list.
                return new List<MyDataPoco>();
            }
        }
    }
    
