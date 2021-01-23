    public class ActivationCode{
        public virtual int LoginAccountId { get; set; }
        protected virtual string ActivatedCode { get; set; }
        protected virtual DateTime ActivationDate { get; set; }
        
        public void Foo(){
            var x = this.ActivatedCode; // Valid
        }
   }
   
    public class Foo{
        new ActivationCode().ActivatedCode //Invalid access
    }
