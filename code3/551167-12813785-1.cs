    public interface IActiveUsersQuery : IQuery // can be ommited
    {
        public int InData1 { get; set; }
        public string InData2 { get; set; }
        public List<string> OutData1 { get; }
    }
    public class ActiveUsersQuery : QueryBase, IActiveUsersQuery
    {
        public int InData1 { get; set; }
        public string InData2 { get; set; }
        public List<string> OutData1 { get; private set; }
        public override void Execute()
        {
            OutData1 = Context.{do something with InData1 and InData};
        }
    }
