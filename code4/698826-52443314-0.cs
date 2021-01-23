    public class DriveInfoEqualityComparer : IEqualityComparer<DriveInfo>
    {
        public bool Equals(DriveInfo x, DriveInfo y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            // compare with Drive Level
            return x.VolumeLabel.Equals(y.VolumeLabel);
        }
        public int GetHashCode(DriveInfo obj)
        {
            return obj.VolumeLabel.GetHashCode();
        }
    }
