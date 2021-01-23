    public class Logger {
    
      public interface LogOutput {
        void out(final String s);
      }
      // Composite - use to send logging to several destinations
      public LogOutput makeComposite(final LogOutput... loggers) {
        return new LogOutput() {
          void out(final String s) {
            for (final LogOutput l : loggers) {
              l.out(s);
            }
          }
        }
      }
    
      
      private static currentLogger = new LogOutput() {
        void out(final String s) {
           // Do nothing as default - no strategy set
        }
      }
    
      public static log(final String s) {
        currentLogger.out(s);
      }
    
      // Strategy: Set a new strategy for output
      public static setLogger(final LogOutput l) {
        currentLogger = l;
      }
    
    }
