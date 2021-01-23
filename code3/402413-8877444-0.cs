      class Foo
      {
         object synch = new object();
         void TheMethod()
         {
            lock (synch)
            {
               salbapi.Sislemcu_Epayroll_Salffs_Bapi(...);
            }
         }
      
}
