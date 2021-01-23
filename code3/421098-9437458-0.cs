    public class Test2
    {
    	public string B { get; set; }
    
    	public override string ToString()
    	{
    		return this.B;
    	}
    }
   
----------
    <ListBox ItemsSource="{Binding Bs}" 
    	Margin="5"/>
