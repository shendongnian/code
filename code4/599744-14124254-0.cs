    public MemberDTO CreateMember(MemberDTO memberDTO)
    {
       //Domain.Model.Member
       var member = MemberFactory.CreateMember(MemberService.GenerateUserName(), memberDTO.Password); 
    
       SaveMember(member); //Repository method?
    
       //Pass DTO to presentation layer
       return Mapper.Map<Member, MemberDTO>(member);
    }
