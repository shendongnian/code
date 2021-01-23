     public class MachineController : Controller {
       private readonly IRepository<MachineRecord> _machineRecords;
       private readonly IRepository<GroupRecord> _groupRecords;
       
       public MachineController(IRepository<MachineRecord> machineRecords, IRepository<GroupRecord> groupRecords) {
         _machineRecords = machineRecords;
         _groupRecords = groupRecords;
       }
       public void AddDummyData(){
         // create a grouprecord in the database
         _groupRecords.Create(new GroupRecord { Id = 1, GroupName = "One" });
         
         // get the groupRecord just created (annoying that Create doesnt return the instance, 
         // but I dont know a way around this
         var groupRecord = _groupRecords.Fetch(x => x.Id == 1);
         
         // create a machine return with the grouprecord assigned to the GroupRecord property 
         _machineRecords.Create(new MachineRecord { 
            Id = 1,
            ..
            GroupRecord = groupRecord
         });
       }
     }
