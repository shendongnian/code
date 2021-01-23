    public class ObjectiveDetail
    {
        public int ObjectiveDetailId { get; set; }
        // other properties ...
        public override bool Equals(object obj)
        {
            var obj2 = obj as ObjectiveDetail;
            if (obj2 == null) return false;
            return ObjectiveDetailId == obj2.ObjectiveDetailId;
        }
        public override int GetHashCode()
        {
            return ObjectiveDetailId;
        }
    }
