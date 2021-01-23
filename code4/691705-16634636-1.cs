        public class TeamComparer : IEqualityComparer<teamDetails>
        {
            public bool Equals(teamDetails x, teamDetails y)
            {
                if (x.teamName == y.teamName) return true;
                return false;
            }
            public int GetHashCode(teamDetails obj)
            {
                if (Object.ReferenceEquals(obj, null)) return 0;
                return obj.teamName.GetHashCode();
            }
        }
