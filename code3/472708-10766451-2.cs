    public class MyDataSource : INotifyPropertyChanged
    {
        private Database db;
        public MyDataSource()
        {
            db = new Database()
            {
                TableA = new List<TableA> 
                {
                    new TableA { ID = 1, Name = "Hello world!" }
                },
                TableB = new List<TableB>
                {
                    new TableB { ID = 1 }
                },
                TableC = new List<TableC>
                {
                    new TableC { ID = 1 },
                    new TableC { ID = 2 }
                }
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<MyConcreteClass> MyConcreteClass
        {
            get { return this.MyQuery(); }
        }
        private IEnumerable<MyConcreteClass> MyQuery()
        {
            var qry = from itemA in db.TableA
                      join itemB in db.TableB on itemA.ID equals itemB.ID
                      join itemC in db.TableC on itemA.ID equals itemC.ID
                      select new MyConcreteClass
                      {
                          TableA = itemA,
                          TableB = itemB,
                          TableC = itemC
                      };
            return qry.AsEnumerable();
        }
    }
