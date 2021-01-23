    class Class1
       {
        public int AddNumb(int numb1, int numb2)
        {
          int ans = numb1 + numb2;
          return ans;
        }
    
      [STAThread]
      static void Main(string[] args)
      {
         Type type1 = typeof(Class1); 
         //Create an instance of the type
         object obj = Activator.CreateInstance(type1);
         object[] mParam = new object[] {5, 10};
         //invoke AddMethod, passing in two parameters
         int res = (int)type1.InvokeMember("AddNumb", BindingFlags.InvokeMethod,
                                            null, obj, mParam);
         Console.Write("Result: {0} \n", res);
       }
      }
