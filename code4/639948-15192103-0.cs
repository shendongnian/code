    public class PartyRoleRelationship<T> where T : PartyRole 
    {
         T _FirstRole;
         T _SecondRole;
         public PartyRoleRelationship(T role1, T role2) {
             _FirstRole = role1;
             _SecondRole = role2;
             role1.ProvisionRelationship(role2)
         }
         
         public ProvisionRelationship(T otherRole) {
              // Do whatever you want here
         }
           
    }
