    public interface IFoo<T> where T : IBarConfig {
    	void Bar(T parameters);
    }
    
    public class MyBarConfig: IBarConfig {
        public String ID { get; set; }
        public long IndexSegmentSize { get; set; } 
    }
    public class MyFoo : IFoo<MyBarConfig> {
      public void Bar(MyBarConfig config) {
    	//Implementation
      }
    }
