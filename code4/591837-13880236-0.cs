    namespace foo
        {
        public delegate void delegat(int a);
        Class a
        {
          public event delegat exit;
          private void a_FormClosed(object sender, FormClosedEventArgs e)
            {
    if(exit != null)
    {
             exit(100);//here should run my event named exit but i get exception!
        }
             }
         }
        }
        
         Class b
         {
          a instance=new a();
          instance.exit+=new delegat(my_fun);
          ...
          priavte void my_fun(int x)
          {
           if(x==100)
            do_smth;
           ...
           }
         }
