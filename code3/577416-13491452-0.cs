    5.4 Purity
    All methods called within a contract must be pure: that is, they must not update
    any pre-existing state. (A pure method is allowed to modify objects that have been
    created after entry into the pure method.) Code Contract tools currently assume
    the following things are pure:
    * Methods marked [Pure] (If a type is marked [Pure], then that applies to all of
      its methods.) The pure attribute is dened in the contract library. (Section 4.3)
    * Property getters.
    * Operators (static methods whose names start with op , have one or two parameters
      and a non-void return type).
    * Any method whose fully qualified name begins with
      System.Diagnostics.Contracts.Contract, System.String, System.IO.Path, or
      System.Type.
    * Any invoked delegate, provided that the delegate type itself is attributed with
      [Pure]. The existing delegate types System.Predicate<T> and System.Comparison<T>
      are considered pure.
    In the future, there will be a purity checker that will enforce these assumptions.
