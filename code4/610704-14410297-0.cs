    public class MyData {
    	private Dictionary<string, object> myData;
    	public MyData {
    		this.myData = new Dictionary<string, object>();
    	}
    
    	public decimal LastVersion { get { return (decimal)this.myData["LastVersion"]; } private set { this.myData["LastVersion"] = value; } }
    
    	public PrimaryAbility STR { get { return (PrimaryAbility)this.myData["STR"]; } private set { this.myData["STR"] = value; } }
    	public PrimaryAbility DEX { get { return (PrimaryAbility)this.myData["DEX"]; } private set { this.myData["DEX"] = value; } }
    	public PrimaryAbility CON { get { return (PrimaryAbility)this.myData["CON"]; } private set { this.myData["CON"] = value; } }
    	public PrimaryAbility INT { get { return (PrimaryAbility)this.myData["INT"]; } private set { this.myData["INT"] = value; } }
    	public PrimaryAbility WIS { get { return (PrimaryAbility)this.myData["WIS"]; } private set { this.myData["WIS"] = value; } }
    	public PrimaryAbility CHA { get { return (PrimaryAbility)this.myData["CHA"]; } private set { this.myData["CHA"] = value; } }
    
    	public DerivedAbility HP { get { return (DerivedAbility)this.myData["HP"]; } private set { this.myData["HP"] = value; } }
    	public DerivedAbility MP { get { return (DerivedAbility)this.myData["MP"]; } private set { this.myData["MP"] = value; } }
    	public DerivedAbility SP { get { return (DerivedAbility)this.myData["SP"]; } private set { this.myData["SP"] = value; } }
    	public DerivedAbility AC { get { return (DerivedAbility)this.myData["AC"]; } private set { this.myData["AC"] = value; } }
    }
