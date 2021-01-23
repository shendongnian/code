    class MainClass {
       static void Main(string[] args) {
          // Where ProcessingStrategy is your abstract class.
          // SpecificProcessingStrategy is someone else's implementation.
          //
          ProcessingStrategy strategy = new SpecificProcessingStrategy();
    
          // Processor is implemented and provided by you and calls the appropriate methods on the 
          // ProcessingStrategy..
          // 
          Processor processor = new Processor( strategy );
          processor.Process();
       }
    }
