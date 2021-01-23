    public static void doThis(string[] array){
       byte[][] buffer = new byte[array.Length][];
       for(int i = 0 ; i < array.Length ; i++)
       {
          buffer[i] = System.Text.Encoding.UTF8.GetBytes(array[i]);
       }
       doThisC(buffer);     
    }
