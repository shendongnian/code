	using System;
	namespace CharTest
	{
		class Program
		{
			public static void Main(string[] args)
			{	ByteToCharTest( 's' );
				ByteToCharTest( 'ы' );
				
				Console.ReadLine();
			}
			
			static void ByteToCharTest( char c )
			{	const string MsgTemplate =
					"Casting to byte character # {0}: {1}";
				
				string msgRes;
				byte   b;
				
				msgRes = "Success";
				try
				{	b = ( byte )c;  }
				catch( Exception e )
				{	msgRes = e.Message;  }
				
				Console.WriteLine(
					String.Format( MsgTemplate, (Int16)c, msgRes ) );
			}
		}
	}
