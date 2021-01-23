    private static ConditionalWeakTable<GameObject, List<Member>> dict = new ConditionalWeakTable<GameObject, List<Member>>();
    
    public static List<Member> GetMemberList(this GameObject go)
    {
      return dict.GetOrCreateValue(go);
    }
