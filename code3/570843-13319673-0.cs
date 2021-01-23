    public interface I2 { 
        string Property1 {get; set;}
        string Property2 {get; set;}
    }
    public class C2 : C1, I2 {
        public string Property2 {get; set;}
        public override void OnEvent() {base.OnEvent(); /*populate property2...*/}
    }
