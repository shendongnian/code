    public abstract class Animal {
         public abstract AnimalType { get; }
         public sealed override string ToString() {
              return String.Format("{0}={1}", AnimalType, this.GetAttributes());
         }
    
    	protected abstract string GetAttributes();
    }
    
    public sealed class Horse {
    	protected override string GetAttributes() {
    		return String.Format("{0}({1}", _name, _age);
    	}
    }
