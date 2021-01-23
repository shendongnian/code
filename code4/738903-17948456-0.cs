             public class Parser<T> : IParser<T>
                {
                    IList<T> ParseDataTableToList(DataTable dataTable, object o)
                    {
                        var list = new List<T>();
        //Your parsing logic can go:
        //1) Here(using with reflection, for example) or 
        //2) in the constructor for Motor/Switchboard object, 
        //in witch case they will take a reader or row object
                        return list;
                    }
                }
                public class Repo<T> : IInsertOrUpdateList<T>
                {
                    void InsertOrUpdate(IList<T> list)
                    {
                        //...
                    }
                }
