    public class Builder : I
    {
      public Not_A A()
      {
        throw new NotImplementedException();
      }
      public Not_B B()
      {
        throw new NotImplementedException();
      }
      public Not_C C()
      {
        throw new NotImplementedException();
      }
    }
    public interface Empty { }
    public interface I : A<Not_A>, B<Not_B>, C<Not_C>, Empty { }
    public interface A<TRemainder> { TRemainder A(); }
    public interface B<TRemainder> { TRemainder B(); }
    public interface C<TRemainder> { TRemainder C(); }
    public interface Not_A : B<Not_AB>, C<Not_AC> { }
    public interface Not_B : A<Not_AB>, C<Not_BC> { }
    public interface Not_C : A<Not_AC>, B<Not_BC> { }
    public interface Not_AB : C<Empty> { }
    public interface Not_BC : A<Empty> { }
    public interface Not_AC : B<Empty> { }
