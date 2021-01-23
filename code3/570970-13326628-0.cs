    public class MemberCanonical : IMemberCanonical
    {
        [BsonId]
        public ObjectId Id { get; set; }
---------     
        
    this.membershipcollection.Insert(memberObj, SafeMode.True);
    var idYouLookingFor = memberObj.Id;
