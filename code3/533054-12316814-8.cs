    public void testab() {
                A existingA = new A {
                    Name = "test a"
                };
    
                using (ABEntities context = new ABEntities()) {
                    context.A.AddObject(existingA);
    
                    context.SaveChanges();
                }
    
    
                using (ABEntities context = new ABEntities()) {
                    B newB = new B {
                        Name = "test b"
                    };
    
                    context.Attach(existingA);
                    existingA.B.Add(newB);
                    context.SaveChanges();
                }
            }
