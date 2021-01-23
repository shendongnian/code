     public class RolloutManager {
       ...
       // If you just update state and you have no input from somewhere else, you can just  
       // read and write in the same method
       public void UpdateRolloutState() {
           using( var db = new MyDBContext() {
                var stuffToUpdate = db.Rollouts.Where(....).ToList();
                foreach(var stuff in StuffToUpdate){
                    stuff.PropertyToUpdate = ....;
                }
                db.SaveChanges();
            }
       }
       // If you have inputs, read them up and do the updates
       public void UpdateRolloutState(IEnumerable<InputRollout> stuffToUpdate) {
           using( var db = new MyDBContext() {
                foreach(var stuff in StuffToUpdate){
                    var dbRollout = db.Rollouts.Find(stuff.Id);
                    // copy properties you want to update
                }
                db.SaveChanges();
            }
       }
