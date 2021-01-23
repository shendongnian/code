    using(var tx1 = new TransactionScope())
    {
       cx.Execute("insert into atable(id) values(123123)");
       
       using(var tx2 = new TransactionScope())
       {
            cx.Execute("insert into atable(id) values(123127)");
            tx2.Complete();
       }
    
       tx1.Complete()
    }
