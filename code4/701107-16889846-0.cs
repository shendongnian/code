    private readonly static lockObj = new object();
     public static void A() {
         lock(lockObj){
           //.. your code here
         }
        }
     public static void B() {
         lock(lockObj){
           //.. your code here
         }
        }
      public static void C() {
         lock(lockObj){
           //.. your code here
         }
        }
      public static void D() {
         lock(lockObj){
           //.. your code here
         }
        }
