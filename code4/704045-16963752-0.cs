            Foo foo=null;
            using (var db = new MyContext())
            {
                db.Foos.Add( new Foo { MyValue = OLD_VALUE } );
                db.SaveChanges();   // foo written to DB with MyValue = OLD_VALUE
                foo = db.Foos.FirstOrDefault(); // grab foo
            }
            // leave context and update foo...
            foo.MyValue = NEW_VALUE;
            using (var db = new MyContext())
            {
                db.Foos.Attach(foo);    // foo is attached in the 'unchanged' state...
                db.SaveChanges();       // ...so this statement has no effect
                // At this point, db.Foos.FirstOrDefault().MyValue will be NEW_VALUE, yet
                // the "real" value of the object in the DB is OLD_VALUE.
                db.Entry(foo).State = EntityState.Modified; // setting foo to "Modified" will cause...
                db.SaveChanges();                           // ...foo to be written out with NEW_VALUE
            }
