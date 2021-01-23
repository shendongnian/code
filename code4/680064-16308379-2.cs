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
       // If you have inputs, pass them in (using a different object normally, such as a wcf 
       //contract or viewmodel), read them up from the db, update the db entities and save
       public void UpdateRolloutState(IEnumerable<InputRollout> stuffToUpdate) {
           using( var db = new MyDBContext() {
                foreach(var stuff in StuffToUpdate){
                    var dbRollout = db.Rollouts.Find(stuff.Id);
                    // copy properties you want to update
                }
                db.SaveChanges();
            }
       }
