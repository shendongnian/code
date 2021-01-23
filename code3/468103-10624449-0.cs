    // need to add
    // using System.Linq;
    
    void Main()
    {
    	var path = @"C:\myfile.csv";
    	string csv = System.IO.File.ReadAllText( path );
    	var array = csv.Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries);
        // Do the mapping with your databinding object
    	var personArray = array.Select(p => new Person { Name = p}); 
       // You need to have this DataContext defined somewhere, for instance using LinqToSql
    	using(var context = new PersonDataContext()){ 
    		context.InsertAllOnSubmit(personArray);
    		context.SubmitChanges();
    	} 
    }
    
    // Imagine this class is one of linqToSql class
    public class Person{
    	public string Name {get;set;}
    }
