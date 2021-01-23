    public class RepositoryBase<TPoco> : where TPoco :    BaseObject {
        public RepositoryBase(BosBaseDbContext context) { Context = context; }
....
        
       /// <summary>
        /// Add new POCO 
        /// </summary>
        public virtual OperationResult Add(TPoco poco) {
            var opResult = new OperationResult();
            try {
              Context.Set<TPoco>().Add(poco);
            }
            catch (Exception ex) {
             .... custom error tool
                return opResult;
            }
            return opResult;
        }
         /// <summary>
        /// Poco must already be attached,, detect chnages is triggered
        /// </summary>
        public virtual OperationResult Change(TPoco poco) {
            var opResult = new OperationResult();
            try {    // ONLY required if NOT using chnage tracking enabled
                Context.ChangeTracker.DetectChanges();
            }
            catch (Exception ex) {
             .... custom error tool
                return opResult;
            }
            return opResult;
        }
