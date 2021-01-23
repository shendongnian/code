    class C : I<Animal> 
    { public Animal M() { return new Giraffe(); } }
    ...
    I<Animal> ia = new C<Animal>(); 
    I<Tiger> it = ia; // Contravariant!
    Tiger t = it.M(); // We just assigned a giraffe to a variable of type tiger.
