     class Supplier
     {
          public Supplier()
          {
              this.suppliers = new HashedSet<Supplier>();
          }
          public virtual ICollection<Product> products { get; private set; }
     }
