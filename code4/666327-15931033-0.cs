    public class Store : MPropertyAsStringSettable {
        .......
        public DateTime lastShiftTime { 
            get{
                MyDbContext curContext = MyWebProject.Controllers.MyBaseController.database;
                if (curContext != null) {
                    return (from shift in curContext.Shifts where shift.SiteID == ID select shift.ShiftDate).First();
                } else {
                    return new DateTime(0);
                }
            }
        }
    }
