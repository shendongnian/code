    public class SomeDirTraverser
    {
        private static List<GroupObj> _groups = new List<GroupObj>();
        public List<string> GetMembershipWithPath(string groupname)
        {
            List<string> retVal = new List<string>();
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, groupname);
            if (grp != null)
            {
                BuildHList(grp, 0, null);
                foreach (UserPrincipal usr in grp.GetMembers(true))
                    retVal.Add(GetMbrPath(usr));
            }
            return retVal;
        }
        private void BuildHList(GroupPrincipal node, int level, GroupPrincipal parent)
        {
            PrincipalSearchResult<Principal> rslts = node.GetMembers();
            _groups.Add(new GroupObj() { Group = node, Level = level, Parent = parent });
            foreach (GroupPrincipal grp in rslts.Where(g => g is GroupPrincipal))
                BuildHList(grp, level + 1, node);
        }
        private string GetMbrPath(UserPrincipal usr)
        {
            Stack<string> output = new Stack<string>();
            StringBuilder retVal = new StringBuilder();
            GroupObj fg = null, tg = null;
            output.Push(usr.Name);
            foreach (GroupObj go in _groups)
            {
                if (usr.IsMemberOf(go.Group))
                {
                    output.Push(go.Group.Name);
                    fg = go;
                    while (fg.Parent != null)
                    {
                        output.Push(fg.Parent.Name);
                        tg = (from g in _groups where g.Group == fg.Parent select g).FirstOrDefault();
                        fg = tg;
                    }
                    break;
                }
            }
            while (output.Count > 1)
                retVal.AppendFormat("{0} ->", output.Pop());
            retVal.Append(output.Pop());
            return retVal.ToString();
        }
    }
    public class GroupObj
    {
        public GroupPrincipal Group { get; set; }
        public int Level { get; set; }
        public GroupPrincipal Parent { get; set; }
    }
