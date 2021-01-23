                public class DBMetaDetails
                {
                    public struct DbTable
                    {
                        public DbTable(string tableName, int tableId): this()
                        {
                            this.Name = tableName;
                            this.ID = tableId;
                        }
                        public string HtmlOutput;
                        public string Name { get; private set; }
                        public int ID { get; private  set; }
                    }
                    public struct SProc
                    {
                        public SProc(string SProcName, int SprocID, List<SqlParameter> CurrSpParList)
                            : this()
                        {
                            this.Name = SProcName;
                            this.ID = SprocID;
                            this.SpParList = CurrSpParList;
                        }
                        public string Name { get; private set; }
                        public int ID { get; private set; }
                        public List<SqlParameter> SpParList { get; private set; }
                    }
                }
