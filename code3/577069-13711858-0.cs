      public static void Main(){
          try{
              MyPreviousEntryClass.Main();
          } catch (Exception x){
             Exception ix = x;
             while (ix!=null){
                MessageBox.Show("Exception: "+ix);
             }
          }
      }
