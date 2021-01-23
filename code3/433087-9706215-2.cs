    public class GuidSearch : IAuditSearch {
        Guid ID;
        public GuidSearch(Guid id) {
            this.ID = id;
        }
        public bool Match(IAudit entry) {
            /* search implementation using ID(Guid)*/
            throw new NotImplementedException();
        }
        
    }
    public class IDRangeSearch : IAuditSearch {
        int StartID;
        int EndID;
        public IDRangeSearch(int startId, int endId) {
            this.StartID = startId;
            this.EndID = endId;
        }
        public bool Match(IAudit entry) {
            /* search implementation using ID range (StartID...EndID)*/
            throw new NotImplementedException();
        }
    }
