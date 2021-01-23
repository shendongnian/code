    public class MyRequiredMemberSelector : IRequiredMemberSelector
    {
        public bool IsRequiredMember(System.Reflection.MemberInfo member)
        {
            return false;
        }
    }
