    public class ItemDTO
    {
        public override bool Equals(object obj)
        {
            var otherItem = obj as ItemDTO;
            if (otherItem == null)
            {
                // this will be because either 'obj' is null or it is not of type ItemDTO.
                return false;
            }
            return otherItem.SomeProperty == this.SomeProperty 
                   && otherItem.OtherProperty == this.OtherProperty;
        }
    }
