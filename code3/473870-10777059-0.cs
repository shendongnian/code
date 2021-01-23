    public class BaseClass {
        public BaseClass(Action<string> abs1 = null, Action<string> abs2 = null){
           AbstractMethod1 = abs1 ?? s=>{};
           AbstractMethod2 = abs2 ?? s=>{};
        }
        public Action<string> AbstractMethod1 {get; private set;}
        public Action<string> AbstractMethod2 {get; private set;}
    }
