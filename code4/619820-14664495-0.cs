    public class Thing { ...
        private nestedType member_nestedMember;
        public struct MemberProxy {
            Thing _owner;
            internal MemberProxy(Thing owner) {_owner = owner;}
            nestedType nestedMember {
                get {return _owner.member_nestedMember;}
                set {_owner.member_nestedMember = value; }
            }
        }
        public MemberProxy someMember {get {return new MemberProxy(this);} }
    }
