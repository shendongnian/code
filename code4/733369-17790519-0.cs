    class TestClass {
        public int num { get; set; }  
        public int max { get; set; }   
        double[][] rawData;
        public TestClass(double[,] values)
        {
               rawData = new double[10][];  
               for (int i = 0; i < 10; i++)
               {
                   rawData[i] = new double[] { values[i, 2], stockvalues[i, 0] };  // if data won't fit into memory, stream through external storage
               }
               this.num = 3;  
               this.max = 30; 
         } 
         public int[] CheckValue() 
         {............}      
      }
