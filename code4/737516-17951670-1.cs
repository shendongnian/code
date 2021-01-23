         public class  Repository<TPoco>{
         /....
         public DbEntityEntry<T> Entry(T entity) { return Context.Entry(entity); }
         public virtual IList<ChangePair> GetChanges(object poco) {
         
            var changes = new List<ObjectPair>();
            var thePoco = (TPoco) poco;
            foreach (var propName in Entry(thePoco).CurrentValues.PropertyNames) {
                var curr = Entry(thePoco).CurrentValues[propName];
                var orig = Entry(thePoco).OriginalValues[propName];
                if (curr != null && orig != null) {
                    if (curr.Equals(orig)) {
                        continue;
                    }
                }
                if (curr == null && orig == null) {
                    continue;
                }
                var aChangePair = new ChangePair {Key = propName, Current = curr, Original = orig};
                changes.Add(aChangePair);
            }
            return changes;
        }
        ///...  partial repository shown
        } 
    // FYI the simple return structure
    
    public class ChangePair {
        public string Key { get; set; }
        public object Original { get; set; }
        public object Current { get; set; }
     }
