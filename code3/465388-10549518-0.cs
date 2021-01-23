    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			IList<PipesList> lstPipeTypes = new List <PipesList>();
    
    			lstPipeTypes.Add(new PipesList("PVC Pipes"));
    			(lstPipeTypes[0]).Pipes.Add(new Pipe("The blue pipe", 12));
    			(lstPipeTypes[0]).Pipes.Add(new Pipe("The red pipe", 15));
    			(lstPipeTypes[0]).Pipes.Add(new Pipe("The silver pipe", 6));
    			(lstPipeTypes[0]).Pipes.Add(new Pipe("The green pipe", 52));
    
    			lstPipeTypes.Add(new PipesList("Iron Pipes"));
    			(lstPipeTypes[1]).Pipes.Add(new Pipe("The gold pipe", 9));
    			(lstPipeTypes[1]).Pipes.Add(new Pipe("The orange pipe", 115));
    			(lstPipeTypes[1]).Pipes.Add(new Pipe("The pink pipe", 1));
    
    			lstPipeTypes.Add(new PipesList("Chrome Pipes"));
    			(lstPipeTypes[2]).Pipes.Add(new Pipe("The grey pipe", 12));
    			(lstPipeTypes[2]).Pipes.Add(new Pipe("The black pipe", 15));
    			(lstPipeTypes[2]).Pipes.Add(new Pipe("The white pipe", 19));
    			(lstPipeTypes[2]).Pipes.Add(new Pipe("The brown pipe", 60));
    			(lstPipeTypes[2]).Pipes.Add(new Pipe("The peach pipe", 16));
    
    
    			RemoveTheSmallPipes(lstPipeTypes);
    		}
    
    
    		public static IList<PipesList> RemoveTheSmallPipes(IList<PipesList> lstPipeTypes)
    		{
    
    			foreach (var pipesList in lstPipeTypes)
    			{
    				pipesList.Pipes = pipesList.Pipes.Where(p => p.length >= 19).ToList();
    			}
    
    			return lstPipeTypes;
    		}
    	}
    
    	class PipesList
    	{
    		public string pipeType;
    		public IList<Pipe> Pipes;
    
    		public PipesList(string newBoxType)
    		{
    			pipeType = newBoxType;
    			Pipes = new List <Pipe>();
    		}
    	}
    
    	class Pipe
    	{
    		public string name;
    		public float length;
    
    		public Pipe(string newName, float newLength)
    		{
    			this.name = newName;
    			this.length = newLength;
    		}
    	}
    
    
    }
