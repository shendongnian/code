    public class JobComparer : EqualityComparer<Job>
    {
        public override bool Equals(Job x, Job y)
        {
            return x.JobID == y.JobID;
        }
        public override int GetHashCode(Job obj)
        {
            return obj.JobID.GetHashCode();
        }
    }
