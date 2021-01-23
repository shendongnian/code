	using System;
	namespace Log4Net
	{    
		class Program
		{
		    private static readonly log4net.ILog log = log4net.LogManager.GetLogger
		            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		    static void Main(string[] args)
		    {
		        Console.WriteLine("Writing to \"log.txt\" in the same directory as the .exe file.\n");
		        log.Info("Info logging");
		        try
		        {
		            throw new Exception("Exception!");
		        }
		        catch (Exception e)
		        {
		            log.Error("This is my error", e);
		        }
		        Console.WriteLine("[any key to exit]");
		        Console.ReadKey();
		        }
		    }
		}
    }
