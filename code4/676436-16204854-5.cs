    public class Clue
    {
        ...
        public Clue Clone()
        {
            Clue newClue = new Clue();
            newClue.SomeClassType = this.SomeClassType.Clone(); // You'll need to get a clone or copy of all non-immutable class members as well.
            newClue.Id = this.Id;  // Value types are copied by value, so are safe to assign directly.
            newClue.Name = this.Name;  //If Name is a string, then this is safe too, since they are immutable.
            return newClue;
        }
    }
