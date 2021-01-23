    public interface ITakeTrash
    {
        public void TakeTrash(Trash t);
    }
    
    public Son : ITakeTrash
    {
        public void TakeTrash(Trash t);
    }
    
    public class Mum  //Same applies for dad
    {
        Son mySon = ...
    
        mySon.TakeTrash(t);
    }
