            StringBuilder s1 = new StringBuilder("Earth");
            System.Diagnostics.Debug.WriteLine("earth is {0}", s1);
            modifier.modify(s1); //<-------- OK
            System.Diagnostics.Debug.WriteLine("earth is {0}",s1);
            test c=new test();
            StringBuilder aa=c.get();
            System.Diagnostics.Debug.WriteLine("earth is {0}", aa);
            modifier.modify(aa); //<------- Error(not anymore)
            System.Diagnostics.Debug.WriteLine("earth is {0}", c.get());
