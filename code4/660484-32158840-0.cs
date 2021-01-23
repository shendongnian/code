    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary; 
	//[Serializable()]
	public class B
	{
		public int y = 2;
	}
	[Serializable()]
	public class A
	{
		public int x = 2;
		/*[NonSerialized]*/ public B b;
		public static T DeserializeFromBinaryFile<T>(string fileName)
		{
			T instance = default(T);
			FileStream fs = new FileStream(fileName, FileMode.Open);
			try
			{
				BinaryFormatter formatter = new BinaryFormatter();
				instance = (T)formatter.Deserialize(fs);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				fs.Close();
			}
			return instance;
		}
		public static void SerializeBinaryFile<T>(string fileName,T t)
		{
			try
			{
				using (FileStream fs = File.Open(fileName, FileMode.Create))
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(fs, t);
				}
			}
			catch (System.Exception ex)
			{
				
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			A testA = new A();
			A.SerializeBinaryFile("test.dat", testA);
			A testReadA = A.DeserializeFromBinaryFile<A>("test.dat");
		}
	}
