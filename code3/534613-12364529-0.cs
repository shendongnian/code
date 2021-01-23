     class Supplier
     {
          public Supplier()
          {
              this.suppliers = new HashedSet<Supplier>();
          }
          public virtual ICollection<Supplier> suppliers { get; private set; }
     }
