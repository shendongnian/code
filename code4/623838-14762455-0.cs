    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    	interface IPerson
    	{
    	}
    
    	//Have to declare T as out
    	interface ICrazy<out T>
    	{
    	}
    
    	class GTFan : IPerson
    	{
    	}
    
    	class CrazyOldDude : ICrazy<GTFan>
    	{
    	}
    
    	class Program
    	{
    		static void Main(string[] args) {
    			IPerson someone;
    			someone = (IPerson)new GTFan();    // <~~~ No exception here
    
    			ICrazy<GTFan> crazyGTFanatic;
    			ICrazy<IPerson> crazyPerson;
    
    			crazyGTFanatic = new CrazyOldDude() as ICrazy<GTFan>;
    
    			crazyGTFanatic = (ICrazy<GTFan>)(new CrazyOldDude());
    
    			crazyPerson = (ICrazy<IPerson>)crazyGTFanatic;
    		}
    	}
    }
