    public class BrainTeaser {
        /// <summary>
        /// The possible groupings are returned in order of the 'most' desirable first. Equivalent groupings are not returned (e.g. 2 + 1 vs. 1 + 2). Only one representant
        /// of each grouping is returned (ordered ascending. e.g. 1 + 1 + 2 + 4 + 5)
        /// </summary>
        /// <param name="numberOfFriends"></param>
        /// <returns></returns>
        public IEnumerable<PossibleGrouping> Solve(int numberOfFriends) {
            if (numberOfFriends == 1) {
                yield return new PossibleGrouping(1);
                yield break;
            }
            HashSet<PossibleGrouping> possibleGroupings = new HashSet<PossibleGrouping>(new PossibleGroupingComparer());
            foreach (var grouping in Solve(numberOfFriends - 1)) {
                // for each group we create 'n+1' new groups 
                // 1 + 1 + 2 + 3 + 4 
                // Becomes
                //      (1+1) + 1 + 2 + 3 + 4  we can add a friend to the first group
                //      1 + (1+1) + 2 + 3 + 4  we can add a friend to the second group
                //      1 + 1 + (2+1) + 3 + 4  we can add a friend to the third group
                //      1 + 1 + 2 + (3+1) + 4  we can add a friend to the forth group
                //      1 + 1 + 2 + 3 + (4+1) we can add a friend to the fifth group
                //      (1 + 1 + 2 + 3 + 4) + 1  friend has to sit alone
                AddAllPartitions(grouping, possibleGroupings);
            }
            foreach (var possibleGrouping in possibleGroupings.OrderByDescending(x => x)) {
                yield return possibleGrouping;
            }
        }
        private void AddAllPartitions(PossibleGrouping grouping, HashSet<PossibleGrouping> possibleGroupings) {
            for (int i = 0; i < grouping.FriendsInGroup.Length; i++) {
                int[] newFriendsInGroup = (int[]) grouping.FriendsInGroup.Clone();
                newFriendsInGroup[i] = newFriendsInGroup[i] + 1;
                possibleGroupings.Add(new PossibleGrouping(newFriendsInGroup));
            }
            var friendsInGroupWithOneAtTheEnd = grouping.FriendsInGroup.Concat(new[] {1}).ToArray();
            possibleGroupings.Add(new PossibleGrouping(friendsInGroupWithOneAtTheEnd));
        }
    }
    /// <summary>
    /// A possible grouping of friends. E.g.
    /// 1 + 1 + 2 + 2 + 4 (10 friends). The array is sorted by the least friends in an group.
    /// </summary>
    public class PossibleGrouping : IComparable<PossibleGrouping> {
        private readonly int[] friendsInGroup;
        public int[] FriendsInGroup {
            get { return friendsInGroup; }
        }
        private readonly int sum;
        public PossibleGrouping(params int[] friendsInGroup) {
            this.friendsInGroup = friendsInGroup.OrderBy(x => x).ToArray();
            sum = friendsInGroup.Sum();
        }
        public int Sum {
            get { return sum; }
        }
        /// <summary>
        /// determine which group is more desirable. Example:
        /// Consider g1: 1 + 2 + 3 + 4 vs g2: 1 + 1 + 2 + 2 + 4  
        /// Group each sequence by the number of occurrences:
        /// 
        /// group   | g1   | g2
        /// --------|-------------
        /// 1       | 1    | 2
        /// ----------------------
        /// 2       | 1    | 2
        /// ----------------------
        /// 3       | 1    | 0
        /// ----------------------
        /// 4       | 1    | 1
        /// ----------------------
        /// 
        /// Sequence 'g1' should score 'higher' because it has 'less' 'ones' (least desirable) elements. 
        /// 
        /// If both sequence would have same number of 'ones', we'd compare the 'twos'.
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(PossibleGrouping other) {
            var thisGroup = (from n in friendsInGroup group n by n).ToDictionary(x => x.Key,
                                                                                 x => x.Count());
            var otherGroup = (from n in other.friendsInGroup group n by n).ToDictionary(x => x.Key,
                                                                                        x => x.Count());
            return WhichGroupIsBetter(thisGroup, otherGroup);
        }
        private int WhichGroupIsBetter(IDictionary<int, int> thisGroup, IDictionary<int, int> otherGroup) {
            int maxNumberOfFriendsInAGroups = Math.Max(thisGroup.Keys.Max(), otherGroup.Keys.Max());
            for (int numberOfFriendsInGroup = 1;
                 numberOfFriendsInGroup <= maxNumberOfFriendsInAGroups;
                 numberOfFriendsInGroup++) {
                // zero means that the current grouping does not contain a such group with 'numberOfFriendsInGroup'
                // in the example above, e.g. group '3'
                int thisNumberOfGroups = thisGroup.ContainsKey(numberOfFriendsInGroup)
                                             ? thisGroup[numberOfFriendsInGroup]
                                             : 0;
                int otherNumberOfGroups = otherGroup.ContainsKey(numberOfFriendsInGroup)
                                              ? otherGroup[numberOfFriendsInGroup]
                                              : 0;
                int compare = thisNumberOfGroups.CompareTo(otherNumberOfGroups);
                if (compare != 0) {
                    // positive score means that the other group has more occurrences. e.g. 'this' group might have 2 groups with each 2 friends,
                    // but the other solution might have 3 groups with each 2 friends. It's obvious that (because both solutions must sum up to the same value)
                    // this 'solution' must contain a grouping with more than 3 friends which is more desirable.
                    return -compare;
                }
            }
            // they must be 'equal' in this case.
            return 0;
        }
        public override string ToString() {
            return string.Join("+", friendsInGroup.Select(x => x.ToString()).ToArray());
        }
    }
    public class PossibleGroupingComparer : EqualityComparer<PossibleGrouping> {
        public override bool Equals(PossibleGrouping x, PossibleGrouping y) {
            return x.FriendsInGroup.SequenceEqual(y.FriendsInGroup);
        }
        /// <summary>
        /// may not be the best hashcode function. for alternatives look here: http://burtleburtle.net/bob/hash/doobs.html
        /// I got this code from here: http://stackoverflow.com/questions/3404715/c-sharp-hashcode-for-array-of-ints
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int GetHashCode(PossibleGrouping obj) {
            var array = obj.FriendsInGroup;
            int hc = obj.FriendsInGroup.Length;
            for (int i = 0; i < array.Length; ++i) {
                hc = unchecked(hc*314159 + array[i]);
            }
            return hc;
        }
    }
