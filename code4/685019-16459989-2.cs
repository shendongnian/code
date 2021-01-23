            // IsFoo1
            new C().IsFoo1<C>(new C());
            new C().IsFoo1<C>(new D());
            new D().IsFoo1<C>(new C());
            new D().IsFoo1<C>(new D());
            new C().IsFoo1<D>(new D());
            new D().IsFoo1<D>(new D());
            // IsFoo2
            new C().IsFoo2<C>(new C());
            new C().IsFoo2<C>(new D());
            new D().IsFoo2<C>(new C());
            new D().IsFoo2<C>(new D());
            
            //new C().IsFoo2<D>(new D()); // ILLEGAL
            new D().IsFoo2<D>(new D());
