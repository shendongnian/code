    public class MemberRepository
    {
        public void AddMember(Member member)
        {
            // save member
            if (MemberAdded != null)
                MemberAdded(new MemberEventArgs(member, MemberEvent.Add));
        }
    
        public event EventHandler<MemberEventArgs> MemberAdded;
    }
    ...
    
    Observable.FromEventPattern<MemberEventArgs>(h => memberRepository.MemberAdded += h,
                                                 h => memberRepository.MemberAdded -= h)
        .Select(e => e.Member)
        .Subscribe(m => Console.WriteLine("Member "+m+" added!));
