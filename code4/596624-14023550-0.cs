    public interface INeuron 
    {
       double GetValue();
       List<INeuron> GetDependents();
       List<double> GetWeights();
    }
    internal class Neuron : INeuron
    {
       // implementation of INeuron
       // ...
       // implementation of methods only known to own classes
       public void Connect(Neuron target, double weight)
       {
          ...
       }
    }
    
    public class Brain
    {
       private List<Neuron> _allNeurons = new List<Neuron>();       
       public Brain()
       {
          Neuron n1 = new Neuron();
          Neuron n2 = new Neuron();
          n1.Connect(n2,0.5);
          _allNeurons.Add(n1);
          _allNeurons.Add(n2);
       }
       
       public IEnumerable<INeuron> GetAllNeurons() { return _allNeurons.Cast<INeuron>(); }
    }
    
    
