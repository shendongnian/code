    public static List<HashSet<GroupPair>> GetGroups(IEnumerable<GroupPair> pairs)
    {
       var groups = new List<HashSet<GroupPair>();
    
       var unassignedPairs = new HashSet<GroupPair>(pairs);
       while (unassignedPairs.Count != 0)
       {
          var group = new HashSet<GroupPair>();
          var rootPair = unassignedPairs.First();
          group.Add(rootPair);
          unassignedPairs.Remove(rootPair);
          var membersToVisit = new Queue<string>(rootPair.BothObjects);
          var visited = new HashSet<string>();
          while (members.Count != 0)
          {
             string member = membersToVisit.Dequeue();
             visited.Add(member);
             foreach (var newPair in unassignedPairs
                     .Where(p => p.BothObjects.Contains(member)).ToList())
             {
                group.Add(newPair);
                unAssignedPairs.Remove(newPair);
                foreach (var newMember in newPair.BothObjects.Except(visited))
                {
                   membersToVisit.Enqueue(newMember)
                }
             }
          }
          groups.Add(group);
       }
       return groups;
    }
