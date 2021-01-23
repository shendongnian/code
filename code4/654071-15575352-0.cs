    public class A : IClonable {
       public ReferenceType member1;
       public int member2;
       public object Clone() {
           var clone = this.MemberwiseClone() as A;  //shallow copy
           clone.CloneReferenceMembers();            //deep copy
           return clone;
       }
       public virtual void CloneReferenceMembers(){
          this.member1 = this.member1.Clone();
       }
    }
    public class B : A {
       public AnotherReferenceType member3;
       public int member4;
        public override void CloneReferenceMembers(){
           base.CloneReferenceMembers();
           this.member3 = this.member3.Clone();
       }
    }
