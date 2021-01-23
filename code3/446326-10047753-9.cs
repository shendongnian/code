    public class Builder : A<Not_A>, B<Not_B>, C<Not_C>, Not_A, Not_B, Not_C, Not_AB, Not_BC, Not_AC, Empty
    {
      Not_AB A<Not_AB>.A() { return (Not_AB)A(); }
      Not_AC A<Not_AC>.A() { return (Not_AC)A(); }
      Empty A<Empty>.A() { return (Empty)A(); }
      public Not_A A()
      {
        return (Not_A)this;
      }
    
      Not_AB B<Not_AB>.B() { return (Not_AB)B(); }
      Not_BC B<Not_BC>.B() { return (Not_BC)B(); }
      Empty B<Empty>.B() { return (Empty)B(); }
      public Not_B B()
      {
        return (Not_B)this;
      }
    
      Not_AC C<Not_AC>.C() { return (Not_AC)C(); }
      Not_BC C<Not_BC>.C() { return (Not_BC)C(); }
      Empty C<Empty>.C() { return (Empty)C(); }
      public Not_C C()
      {
        return (Not_C)this;
      }
    }
    
    public interface Empty { }
    
    public interface A<TRemainder> { TRemainder A(); }
    public interface B<TRemainder> { TRemainder B(); }
    public interface C<TRemainder> { TRemainder C(); }
    
    public interface Not_A : B<Not_AB>, C<Not_AC> { }
    public interface Not_B : A<Not_AB>, C<Not_BC> { }
    public interface Not_C : A<Not_AC>, B<Not_BC> { }
    
    public interface Not_AB : C<Empty> { }
    public interface Not_BC : A<Empty> { }
    public interface Not_AC : B<Empty> { }
