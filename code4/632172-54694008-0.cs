    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;
    
    namespace StackOverflowDemo
    {
    	public static class Extend
    	{
    		/// <summary>
    		/// Static initializer is used to register the Resolve Event Handler
    		/// </summary>
    		static Extend()
    		{
    			AppDomain.CurrentDomain.AssemblyResolve += ResolveEventHandler;
    		}
    
    		/// <summary>
    		/// This resolver will find any Assembly that is already loaded into
    		/// the current AppDomain and return it.
    		/// <para/>
    		/// You would think this would not be necessary, but the 
    		/// BinaryFormatter.Deserialize method apparently can not 
    		/// find an assembly that has been loaded programmatically
    		/// as a plug-in, and whose DLL does not reside in the same
    		/// folder as the executable file.
    		/// </summary>
    		/// <param name="sender"></param>
    		/// <param name="args"></param>
    		/// <returns></returns>
    		private static Assembly ResolveEventHandler( object sender, ResolveEventArgs args )
    		{
    			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    			Assembly result = (from a in assemblies where args.Name.Equals(a.FullName) select a).FirstOrDefault();
    			return result;
    		}
    
    
    		/// <summary>
    		/// Slow, and requires that the source be marked as [Serializable], but 
    		/// clones *everything* and is not complicated.
    		/// <para/>
    		/// Note that by itself, this method will fail if an attempt is made to
    		/// create a deep copy of an object whose class is contained in an assembly
    		/// that was loaded programmatically (i.e., loaded as a plug-in).
    		/// <para/>
    		/// See https://stackoverflow.com/a/1213649
    		/// <para/>
    		/// and https://stackoverflow.com/a/23017515
    		/// </summary>
    		/// <typeparam name="T"></typeparam>
    		/// <param name="src"></param>
    		/// <returns></returns>
    		public static T DeepClone<T>( this T src )
    		{
    			if (!typeof(T).IsSerializable)
    			{
    				throw new ArgumentException(string.Format("[Extend.DeepClone] Type '{0}' is not Serializable", typeof(T).Name));
    			}
    
    			if (Object.ReferenceEquals(src, null))
    			{
    				return default(T);
    			}
    
    			using (Stream stream = new MemoryStream())
    			{
    				IFormatter formatter = new BinaryFormatter();
    				formatter.Serialize(stream, src);
    				stream.Seek(0, SeekOrigin.Begin);
    				return (T)formatter.Deserialize(stream);
    			}
    		}
    	}
    }
