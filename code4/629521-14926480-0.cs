    public class TruthTable {
    
    	public TruthTable(int sensorCount) {
          if (sensorCount<1 || sensorCount >26) {
            throw new ArgumentOutOfRangeException("sensorCount");
          }
          this.Table=new Sensor[(int)Math.Pow(2,sensorCount)];
    	  for (var i=0; i < Math.Pow(2,sensorCount);i++) {
    		  this.Table[i]=new Sensor(sensorCount);
    		  for (var j = 0; j < sensorCount; j++) {
    			  this.Table[i].Inputs[sensorCount - (j + 1)] = ( i / (int)Math.Pow(2, j)) % 2 == 1;
    		  }
    	   }
    	}	
    	
    	public Sensor[] Table {get; private set;}
    	
    	public string LiveOutputs {
    	  get {
    	  	return string.Join("\n", Table.Where(x => x.Output).Select(x => x.InputsAsString));
    	  }
    	}
    	
    	public string LiveOutPuts2 {
    	get { 
    		return string.Join(" + ", Table.Where(x => x.Output).Select (x => x.InputsAsString2));
    	}
      }
    }
    
    // Define other methods and classes here
    public class Sensor {
    
      public Sensor(int sensorCount) {
        if (sensorCount<1 || sensorCount >26) {
          throw new ArgumentOutOfRangeException("sensorCount");
        }
    	this.SensorCount = sensorCount;
    	this.Inputs=new bool[sensorCount];
      }
    
      private int SensorCount {get;set;}
      public bool[] Inputs { get; private set;}
      public bool Output {get;set;}
      
      public string InputsAsString {
        get {
    		return string.Join(" ",Inputs.Select(x => x.ToString().ToUpper()));
    	}
      }
      
      public string InputsAsString2 {
       get {
          var output=new StringBuilder();
    	  for (var i=0; i < this.SensorCount; i++) {
    	  	var letter = (char)(i+65);
    		output.AppendFormat("{0}{1}",Inputs[i] ? "" : "!", letter);
    	  }
    	  return output.ToString();
        }
      }
    }
